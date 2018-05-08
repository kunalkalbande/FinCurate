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
    public class CompanyFinancialsController : ApiController
    {
        string connstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        TokenEntity tokenEntity = new TokenEntity { Token = ConfigurationManager.AppSettings["fincurateToken"].ToString(), IsSuccess = true, expireDate = DateTime.Now.AddHours(2) };//Login(email, password);
        string email = ConfigurationManager.AppSettings["fincurateEmail"].ToString();
        string Password = ConfigurationManager.AppSettings["fincuratePassword"].ToString();

        // GET: api/CompanyFinancialsDetails
        [HttpPost]
        public HttpResponseMessage PostCompanyFinancialAvailability(HttpRequestMessage request)
        {
            CompanyFinancials objCompanyFinancials = new CompanyFinancials();
            objCompanyFinancials = Common.GetCompanyFinancialAvailability(tokenEntity.Token);
            if (objCompanyFinancials != null) //&& objCompanyFinancials.MessageInfo.MessageCode.Equals(200)
            {
                InsertUpdateCompanyFinancialDetails(objCompanyFinancials, connstring);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            //}
            return request.CreateResponse(HttpStatusCode.NotModified);
            
        }


        // POST: api/CompanyFinancialsDetails
        [HttpPost]
        public HttpResponseMessage PostReturnStatistics(HttpRequestMessage request)
        {

            return request.CreateResponse(HttpStatusCode.NotModified);
        }

        // PUT: api/CompanyFinancialsDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CompanyFinancialsDetails/5
        public void Delete(int id)
        {
        }


        private static void InsertUpdateCompanyFinancialDetails(CompanyFinancials objCompanyFinancials, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.CompanyFinancialAvailability>(objCompanyFinancials.CompanyFinancialAvailabilityEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.CompanyFinancialAvailabilities.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.CompanyFinancialAvailabilities.Add(result);
                    }
                    else
                    {
                        context.CompanyFinancialAvailabilities.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.CompanyFinancialAvailabilities.Add(result);

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
