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
        public HttpResponseMessage PostCompanyFinancialAvailability(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            CompanyFinancials objCompanyFinancials = new CompanyFinancials();
            objCompanyFinancials = Common.GetCompanyFinancialAvailability(tokenEntity.Token, apiRequest);
            if (objCompanyFinancials != null) //&& objCompanyFinancials.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateCompanyFinancialDetails(objCompanyFinancials, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostBalanceSheet(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            BalanceSheetModel objBalanceSheet = new BalanceSheetModel();
            objBalanceSheet = Common.GetBalanceSheet(tokenEntity.Token, apiRequest);
            if (objBalanceSheet != null) //&& objBalanceSheet.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateBalanceSheet(objBalanceSheet, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostCashFlow(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            CashFlowModel objCashFlow = new CashFlowModel();
            objCashFlow = Common.GetCashFlow(tokenEntity.Token, apiRequest);
            if (objCashFlow != null) //&& objCashFlow.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateCashFlow(objCashFlow, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostCashFlowTTM(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            CashFlowModel objCashFlow = new CashFlowModel();
            objCashFlow = Common.GetCashFlowTTM(tokenEntity.Token, apiRequest);
            if (objCashFlow != null) //&& objCashFlow.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateCashFlowTTM(objCashFlow, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostMiscellaneousInfos(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            MiscellaneousInfoModel objMiscellaneousInfo = new MiscellaneousInfoModel();
            objMiscellaneousInfo = Common.GetMiscellaneousInfos(tokenEntity.Token, apiRequest);
            if (objMiscellaneousInfo != null) //&& objMiscellaneousInfo.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateMiscellaneousInfos(objMiscellaneousInfo, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostIncomeStatement(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            IncomeStatementModel objIncomeStatement = new IncomeStatementModel();
            objIncomeStatement = Common.GetIncomeStatement(tokenEntity.Token, apiRequest);
            if (objIncomeStatement != null) 
            {
                bool result = InsertUpdateIncomeStatement(objIncomeStatement, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        #region PrivateMethods
        private static bool InsertUpdateCompanyFinancialDetails(CompanyFinancials objCompanyFinancials, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private static bool InsertUpdateBalanceSheet(BalanceSheetModel objBalanceSheet, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.BalanceSheet>(objBalanceSheet.BalanceSheetEntityList.FirstOrDefault());
                //Todo: change entitymodel--Update edmx
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.BalanceSheets.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.BalanceSheets.Add(result);
                    }
                    else
                    {
                        context.BalanceSheets.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.BalanceSheets.Add(result);

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        private static bool InsertUpdateCashFlow(CashFlowModel objCashFlow, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.CashFlow>(objCashFlow.CashFlowEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.CashFlows.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.CashFlows.Add(result);
                    }
                    else
                    {
                        context.CashFlows.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.CashFlows.Add(result);

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

        private static bool InsertUpdateCashFlowTTM(CashFlowModel objCashFlow, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.CashFlowsTTM>(objCashFlow.CashFlowEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.CashFlowsTTMs.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.CashFlowsTTMs.Add(result);
                    }
                    else
                    {
                        context.CashFlowsTTMs.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.CashFlowsTTMs.Add(result);

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

        private static bool InsertUpdateMiscellaneousInfos(MiscellaneousInfoModel objMiscellaneousInfo, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.MiscellaneousInfo>(objMiscellaneousInfo.MiscellaneousInfoEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.MiscellaneousInfos.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.MiscellaneousInfos.Add(result);
                    }
                    else
                    {
                        context.MiscellaneousInfos.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.MiscellaneousInfos.Add(result);

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

        private static bool InsertUpdateIncomeStatement(IncomeStatementModel objIncomeStatement, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.IncomeStatement>(objIncomeStatement.IncomeStatementEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.IncomeStatements.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.IncomeStatements.Add(result);
                    }
                    else
                    {
                        context.IncomeStatements.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.IncomeStatements.Add(result);

                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        #endregion
    }
}
