﻿using CommonLibrary;
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
        public HttpResponseMessage PostSharesSnapshot(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            SharesSnapshotModel objSharesSnapshot = new SharesSnapshotModel();
            objSharesSnapshot = Common.GetSharesSnapshot(tokenEntity.Token, apiRequest);
            if (objSharesSnapshot != null) //&& objCompanyFinancials.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateSharesSnapshot(objSharesSnapshot, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

    
        private static bool InsertUpdateSharesSnapshot(SharesSnapshotModel objSharesSnapshot, string connstring)
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
