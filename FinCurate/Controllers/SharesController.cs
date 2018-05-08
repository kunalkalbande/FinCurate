using CommonLibrary;
using CommonLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinCurate.Controllers
{
    public class SharesController : ApiController
    {

        string connstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        TokenEntity tokenEntity = new TokenEntity { Token = ConfigurationManager.AppSettings["fincurateToken"].ToString(), IsSuccess = true, expireDate = DateTime.Now.AddHours(2) };//Login(email, password);
        string email = ConfigurationManager.AppSettings["fincurateEmail"].ToString();
        string Password = ConfigurationManager.AppSettings["fincuratePassword"].ToString();


        // GET: api/Shares
        [HttpPost]
        public HttpResponseMessage PostSharesSnapshot(HttpRequestMessage request)
        {
            SharesSnapshotModel objSharesSnapshot = new SharesSnapshotModel();
            objSharesSnapshot = Common.GetSharesSnapshot(tokenEntity.Token);
            if (objSharesSnapshot != null) //&& objCompanyFinancials.MessageInfo.MessageCode.Equals(200)
            {
                InsertUpdateSharesSnapshot(objSharesSnapshot, connstring);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            //}
            return request.CreateResponse(HttpStatusCode.NotModified);
        }

        //// GET: api/Shares/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Shares
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Shares/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Shares/5
        //public void Delete(int id)
        //{
        //}

        private static void InsertUpdateSharesSnapshot(SharesSnapshotModel objSharesSnapshot, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.SharesSnapshot>(objSharesSnapshot.sharesSnapshotEntity);
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.SharesSnapshots.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.SharesSnapshots.Add(result);
                    }
                    else
                    {
                        context.SharesSnapshots.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.SharesSnapshots.Add(result);

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
