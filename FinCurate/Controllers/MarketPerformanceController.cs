using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommonLibrary;
using CommonLibrary.Models;

namespace FinCurate.Controllers
{
    public class MarketPerformanceController : ApiController
    {

        string connstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        TokenEntity tokenEntity = new TokenEntity { Token = ConfigurationManager.AppSettings["fincurateToken"].ToString(), IsSuccess = true, expireDate = DateTime.Now.AddHours(2) };//Login(email, password);
        string email = ConfigurationManager.AppSettings["fincurateEmail"].ToString();
        string Password = ConfigurationManager.AppSettings["fincuratePassword"].ToString();


        // Post: api/MarketPerformance
        [HttpPost]
        public HttpResponseMessage PostReturnStatistics(HttpRequestMessage request)
        {
            ReturnStatistics objReturnStatistics = new ReturnStatistics();
            objReturnStatistics = Common.GetReturnStatistics(tokenEntity.Token);
            if (objReturnStatistics != null)
            {
                InsertUpdateReturnStatistics(objReturnStatistics, connstring);
                return request.CreateResponse(HttpStatusCode.OK, "Return Statistics Posted Successfully");
            }
            //}
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to post data");
        }

        [HttpPost]
        public HttpResponseMessage PostCurrentMarketCapitalization(HttpRequestMessage request)
        {
            MarketCapitalizationModel objMarketCapitalization = new MarketCapitalizationModel();
            objMarketCapitalization = Common.GetCurrentMarketCapitalization(tokenEntity.Token);
            if (objMarketCapitalization != null)
            {
                InsertUpdateMarketCapitalization(objMarketCapitalization, connstring);
                return request.CreateResponse(HttpStatusCode.OK, "Return Statistics Posted Successfully");
            }
            //}
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to post data");
        }

        // POST: api/MarketPerformance
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MarketPerformance/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MarketPerformance/5
        public void Delete(int id)
        {
        }

        private static void InsertUpdateReturnStatistics(ReturnStatistics objReturnStatistics, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.ReturnStatistic>(objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.ReturnStatistics.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.ReturnStatistics.Add(result);
                    }
                    else
                    {
                        context.ReturnStatistics.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.ReturnStatistics.Add(result);

                    context.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private static void InsertUpdateMarketCapitalization(MarketCapitalizationModel objMarketCapitalization, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.MarketCapitalization>(objMarketCapitalization.MarketCapitalizationEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.MarketCapitalizations.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.MarketCapitalizations.Add(result);
                    }
                    else
                    {
                        context.MarketCapitalizations.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.MarketCapitalizations.Add(result);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
