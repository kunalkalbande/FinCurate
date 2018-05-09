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
    public class ExchangeCoverageController : ApiController
    {
        string connstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        TokenEntity tokenEntity = new TokenEntity { Token = ConfigurationManager.AppSettings["fincurateToken"].ToString(), IsSuccess = true, expireDate = DateTime.Now.AddHours(2) };//Login(email, password);
        string email = ConfigurationManager.AppSettings["fincurateEmail"].ToString();
        string Password = ConfigurationManager.AppSettings["fincuratePassword"].ToString();

        [HttpPost]
        public HttpResponseMessage PostStockExchangeSecurity(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            StockExchangeSecurityModel objStockExchangeSecurity = new StockExchangeSecurityModel();
            objStockExchangeSecurity = Common.GetStockExchangeSecurity(tokenEntity.Token, apiRequest);
            if (objStockExchangeSecurity != null)
            {
                bool result = InsertUpdateStockExchangeSecurity(objStockExchangeSecurity, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }



        private static bool InsertUpdateStockExchangeSecurity(StockExchangeSecurityModel objStockExchangeSecurity, string connstring)
        {
            try
            {
                   var result = AutoMapper.Mapper.Map<FinCurate.StockExchangeSecurity>(objStockExchangeSecurity.StockExchangeSecurityEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.StockExchangeSecurities.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.StockExchangeSecurities.Add(result);
                    }
                    else
                    {
                        context.StockExchangeSecurities.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.StockExchangeSecurities.Add(result);

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
    }
}
