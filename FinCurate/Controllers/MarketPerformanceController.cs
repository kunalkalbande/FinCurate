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
        public HttpResponseMessage PostReturnStatistics(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            ReturnStatistics objReturnStatistics = new ReturnStatistics();
            objReturnStatistics = Common.GetReturnStatistics(tokenEntity.Token, apiRequest);
            if (objReturnStatistics != null)
            {
                bool result = InsertUpdateReturnStatistics(objReturnStatistics, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostCurrentMarketCapitalization(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            MarketCapitalizationModel objMarketCapitalization = new MarketCapitalizationModel();
            objMarketCapitalization = Common.GetCurrentMarketCapitalization(tokenEntity.Token, apiRequest);
            if (objMarketCapitalization != null)
            {
                bool result = InsertUpdateMarketCapitalization(objMarketCapitalization, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        #region privateMethodes
        private static bool InsertUpdateReturnStatistics(ReturnStatistics objReturnStatistics, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private static bool InsertUpdateMarketCapitalization(MarketCapitalizationModel objMarketCapitalization, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        #endregion

    }
}
