using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommonLibrary;
using CommonLibrary.Models;
using Newtonsoft.Json;

namespace FinCurate.Controllers
{

    public class ProfitabilityRatiosController : ApiController
    {
        string connstring = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        TokenEntity tokenEntity = new TokenEntity { Token = ConfigurationManager.AppSettings["fincurateToken"].ToString(), IsSuccess = true, expireDate = DateTime.Now.AddHours(2) };//Login(email, password);
        string email = ConfigurationManager.AppSettings["fincurateEmail"].ToString();
        string Password = ConfigurationManager.AppSettings["fincuratePassword"].ToString();

        // GET api/<controller>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            //Common.Login(email, Password);
            //if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
            //{
                ProfitabilityRatios objProfitability = new ProfitabilityRatios();
                objProfitability = Common.GetFinancialKeyRatiosService(tokenEntity.Token);
                if (objProfitability != null && objProfitability.MessageInfo.MessageCode.Equals(200))
                {
                    InsertUpdateProfitabilityRatios(objProfitability, connstring);
                    return request.CreateResponse(HttpStatusCode.OK);
                }
            //}
            return request.CreateResponse(HttpStatusCode.NotModified);
        }

        // GET api/<controller>/5
        [HttpGet]
        public string GetProfitabilityRatiosTTM()
        {
            //Common.Login(email, Password);
            //if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
            //{
            ProfitabilityRatios objProfitability = new ProfitabilityRatios();
            objProfitability = Common.GetProfitabilityRatiosTTM(tokenEntity.Token);
            if (objProfitability != null)
            {
                InsertUpdateProfitabilityRatiosTTM(objProfitability, connstring);
            }
            //}
            return string.Empty;
        }


        [HttpGet]
        public string GetEfficiencyRatios()
        {
            //Common.Login(email, Password);
            //if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
            //{
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            objEfficiencyRatios = Common.GetEfficiencyRatios(tokenEntity.Token);
            if (objEfficiencyRatios != null)
            {
                InsertUpdateEfficiencyRatios(objEfficiencyRatios, connstring);
            }
            //}
            return string.Empty;
        }

        [HttpPost]
        public string PostEfficiencyRatiosTTM()
        {
            //Common.Login(email, Password);
            //if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
            //{
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            objEfficiencyRatios = Common.GetEfficiencyRatiosTTM(tokenEntity.Token);
            if (objEfficiencyRatios != null)
            {
                InsertUpdateEfficiencyRatiosTTM(objEfficiencyRatios, connstring);
            }
            //}
            return string.Empty;
        }

        [HttpPost]
        public HttpResponseMessage PostFinancialHealthRatios(HttpRequestMessage request)
        {
            FinancialHealthRatioModel objFinancialHealthRatio = new FinancialHealthRatioModel();
            objFinancialHealthRatio = Common.GetFinancialHealthRatios(tokenEntity.Token);
            if (objFinancialHealthRatio != null)
            {
                InsertUpdateFinancialHealthRatios(objFinancialHealthRatio, connstring);
                return request.CreateResponse(HttpStatusCode.OK, "FinancialHealthRatios Posted Successfully");
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to post data");
        }


        [HttpGet]
        public string GetReturnStatistics()
        {
            Common.Login(email, Password);
            if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
            {
                ReturnStatistics objReturnStatistics = new ReturnStatistics();
                objReturnStatistics = Common.GetReturnStatistics(tokenEntity.Token);
                if (objReturnStatistics != null)
                {
                    InsertUpdateReturnStatistics(objReturnStatistics, connstring);
                }
            }
            return string.Empty; ;
        }


        [HttpPost]
        public HttpResponseMessage PostValuationRatios(HttpRequestMessage request)
        {
            ValuationRatios objValuationRatios = new ValuationRatios();
            objValuationRatios = Common.GetValuationRatios(tokenEntity.Token);
            if (objValuationRatios != null) //&& objValuationRatios.MessageInfo.MessageCode.Equals(200)
            {
                InsertUpdateValuationRatios(objValuationRatios, connstring);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            return request.CreateResponse(HttpStatusCode.NotModified);
        }

        #region PrivateMethods
        
        private static void InsertUpdateProfitabilityRatios(ProfitabilityRatios objProfitability, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.ProfitabilityRatio>(objProfitability.ProfitabilityEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.ProfitabilityRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.ProfitabilityRatios.Add(result);
                    }
                    else
                    {
                        context.ProfitabilityRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.ProfitabilityRatios.Add(result);

                    context.SaveChanges();

                }


                //using (SqlConnection connection = new SqlConnection(connstring))
                //{
                //    SqlCommand CmdRecordExist = new SqlCommand("SELECT COUNT(*) FROM dbo.ProfitabilityRatios WHERE ([Symbol] = @Symbol)", connection);
                //    CmdRecordExist.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //    connection.Open();
                //    int RecordExist = (int)CmdRecordExist.ExecuteScalar();
                //    connection.Close();
                //    if (RecordExist > 0)
                //    {
                //        String UpdateQuery = "Update dbo.ProfitabilityRatios set Symbol = @Symbol,ReportDate = @ReportDate,PeriodEndingDate =@PeriodEndingDate,FileDate =@FileDate,StatementType =@StatementType,DataType=@DataType,CurrencyId =@CurrencyId,FiscalYearEnd =@FiscalYearEnd,GrossMargin=@GrossMargin,OperatingMargin=@OperatingMargin,EBTMargin =@EBTMargin,TaxRate=@TaxRate,NetMargin=@NetMargin,SalesPerEmployee=@SalesPerEmployee,EBITMargin=@EBITMargin,EBITDAMargin=@EBITMargin,NormalizedNetProfitMargin=@NormalizedNetProfitMargin,InterestCoverage=@InterestCoverage,IncPerEmployeeTotOps=@IncPerEmployeeTotOps,AccessionNumber=@AccessionNumber,FormType=@FormType,NetIncomeperFullTimeEmployee=@NetIncomeperFullTimeEmployee where Symbol = @Symbol";
                //        using (SqlCommand Updatecommand = new SqlCommand(UpdateQuery, connection))
                //        {
                //            Updatecommand.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //            Updatecommand.Parameters.AddWithValue("@ReportDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().ReportDate);
                //            Updatecommand.Parameters.AddWithValue("@PeriodEndingDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().PeriodEndingDate);
                //            Updatecommand.Parameters.AddWithValue("@FileDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().FileDate);
                //            Updatecommand.Parameters.AddWithValue("@StatementType", objProfitability.ProfitabilityEntityList.FirstOrDefault().StatementType);
                //            Updatecommand.Parameters.AddWithValue("@DataType", objProfitability.ProfitabilityEntityList.FirstOrDefault().DataType);
                //            Updatecommand.Parameters.AddWithValue("@CurrencyId", objProfitability.ProfitabilityEntityList.FirstOrDefault().CurrencyId);
                //            Updatecommand.Parameters.AddWithValue("@FiscalYearEnd", objProfitability.ProfitabilityEntityList.FirstOrDefault().FiscalYearEnd);
                //            Updatecommand.Parameters.AddWithValue("@GrossMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().GrossMargin);
                //            Updatecommand.Parameters.AddWithValue("@OperatingMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().OperatingMargin);
                //            Updatecommand.Parameters.AddWithValue("@EBTMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBTMargin);
                //            Updatecommand.Parameters.AddWithValue("@TaxRate", objProfitability.ProfitabilityEntityList.FirstOrDefault().TaxRate);
                //            Updatecommand.Parameters.AddWithValue("@NetMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetMargin);
                //            Updatecommand.Parameters.AddWithValue("@SalesPerEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().SalesPerEmployee);
                //            Updatecommand.Parameters.AddWithValue("@EBITMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITMargin);
                //            Updatecommand.Parameters.AddWithValue("@EBITDAMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITDAMargin);
                //            Updatecommand.Parameters.AddWithValue("@NormalizedNetProfitMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NormalizedNetProfitMargin);
                //            Updatecommand.Parameters.AddWithValue("@InterestCoverage", objProfitability.ProfitabilityEntityList.FirstOrDefault().InterestCoverage);
                //            Updatecommand.Parameters.AddWithValue("@IncPerEmployeeTotOps", objProfitability.ProfitabilityEntityList.FirstOrDefault().IncPerEmployeeTotOps);
                //            Updatecommand.Parameters.AddWithValue("@AccessionNumber", objProfitability.ProfitabilityEntityList.FirstOrDefault().AccessionNumber);
                //            Updatecommand.Parameters.AddWithValue("@FormType", objProfitability.ProfitabilityEntityList.FirstOrDefault().FormType);
                //            Updatecommand.Parameters.AddWithValue("@NetIncomeperFullTimeEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetIncomeperFullTimeEmployee);
                //            connection.Open();
                //            int result = Updatecommand.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //    else
                //    {
                //        String query = "INSERT INTO dbo.ProfitabilityRatios (Symbol,ReportDate,PeriodEndingDate,FileDate,StatementType,DataType,CurrencyId,FiscalYearEnd,GrossMargin,OperatingMargin,EBTMargin,TaxRate,NetMargin,SalesPerEmployee,EBITMargin,EBITDAMargin,NormalizedNetProfitMargin,InterestCoverage,IncPerEmployeeTotOps,AccessionNumber,FormType,NetIncomeperFullTimeEmployee) VALUES (@Symbol,@ReportDate,@PeriodEndingDate,@FileDate,@StatementType,@DataType,@CurrencyId,@FiscalYearEnd,@GrossMargin,@OperatingMargin,@EBTMargin,@TaxRate,@NetMargin,@SalesPerEmployee,@EBITMargin,@EBITDAMargin,@NormalizedNetProfitMargin,@InterestCoverage,@IncPerEmployeeTotOps,@AccessionNumber,@FormType,@NetIncomeperFullTimeEmployee)";
                //        using (SqlCommand command = new SqlCommand(query, connection))
                //        {
                //            command.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //            command.Parameters.AddWithValue("@ReportDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().ReportDate);
                //            command.Parameters.AddWithValue("@PeriodEndingDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().PeriodEndingDate);
                //            command.Parameters.AddWithValue("@FileDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().FileDate);
                //            command.Parameters.AddWithValue("@StatementType", objProfitability.ProfitabilityEntityList.FirstOrDefault().StatementType);
                //            command.Parameters.AddWithValue("@DataType", objProfitability.ProfitabilityEntityList.FirstOrDefault().DataType);
                //            command.Parameters.AddWithValue("@CurrencyId", objProfitability.ProfitabilityEntityList.FirstOrDefault().CurrencyId);
                //            command.Parameters.AddWithValue("@FiscalYearEnd", objProfitability.ProfitabilityEntityList.FirstOrDefault().FiscalYearEnd);
                //            command.Parameters.AddWithValue("@GrossMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().GrossMargin);
                //            command.Parameters.AddWithValue("@OperatingMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().OperatingMargin);
                //            command.Parameters.AddWithValue("@EBTMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBTMargin);
                //            command.Parameters.AddWithValue("@TaxRate", objProfitability.ProfitabilityEntityList.FirstOrDefault().TaxRate);
                //            command.Parameters.AddWithValue("@NetMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetMargin);
                //            command.Parameters.AddWithValue("@SalesPerEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().SalesPerEmployee);
                //            command.Parameters.AddWithValue("@EBITMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITMargin);
                //            command.Parameters.AddWithValue("@EBITDAMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITDAMargin);
                //            command.Parameters.AddWithValue("@NormalizedNetProfitMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NormalizedNetProfitMargin);
                //            command.Parameters.AddWithValue("@InterestCoverage", objProfitability.ProfitabilityEntityList.FirstOrDefault().InterestCoverage);
                //            command.Parameters.AddWithValue("@IncPerEmployeeTotOps", objProfitability.ProfitabilityEntityList.FirstOrDefault().IncPerEmployeeTotOps);
                //            command.Parameters.AddWithValue("@AccessionNumber", objProfitability.ProfitabilityEntityList.FirstOrDefault().AccessionNumber);
                //            command.Parameters.AddWithValue("@FormType", objProfitability.ProfitabilityEntityList.FirstOrDefault().FormType);
                //            command.Parameters.AddWithValue("@NetIncomeperFullTimeEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetIncomeperFullTimeEmployee);
                //            connection.Open();
                //            int result = command.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void InsertUpdateProfitabilityRatiosTTM(ProfitabilityRatios objProfitability, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.ProfitabilityRatio>(objProfitability.ProfitabilityEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.ProfitabilityRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.ProfitabilityRatios.Add(result);
                    }
                    else
                    {
                        context.ProfitabilityRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.ProfitabilityRatios.Add(result);

                    context.SaveChanges();

                }
                //using (SqlConnection connection = new SqlConnection(connstring))
                //{
                //    SqlCommand CmdRecordExist = new SqlCommand("SELECT COUNT(*) FROM dbo.ProfitabilityRatios WHERE ([Symbol] = @Symbol)", connection);
                //    CmdRecordExist.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //    connection.Open();
                //    int RecordExist = (int)CmdRecordExist.ExecuteScalar();
                //    connection.Close();
                //    if (RecordExist > 0)
                //    {
                //        String UpdateQuery = "Update dbo.ProfitabilityRatios set Symbol = @Symbol,ReportDate = @ReportDate,PeriodEndingDate =@PeriodEndingDate,FileDate =@FileDate,StatementType =@StatementType,DataType=@DataType,CurrencyId =@CurrencyId,FiscalYearEnd =@FiscalYearEnd,GrossMargin=@GrossMargin,OperatingMargin=@OperatingMargin,EBTMargin =@EBTMargin,TaxRate=@TaxRate,NetMargin=@NetMargin,SalesPerEmployee=@SalesPerEmployee,EBITMargin=@EBITMargin,EBITDAMargin=@EBITMargin,NormalizedNetProfitMargin=@NormalizedNetProfitMargin,InterestCoverage=@InterestCoverage,IncPerEmployeeTotOps=@IncPerEmployeeTotOps,AccessionNumber=@AccessionNumber,FormType=@FormType,NetIncomeperFullTimeEmployee=@NetIncomeperFullTimeEmployee where Symbol = @Symbol";
                //        using (SqlCommand Updatecommand = new SqlCommand(UpdateQuery, connection))
                //        {
                //            Updatecommand.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //            Updatecommand.Parameters.AddWithValue("@ReportDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().ReportDate);
                //            Updatecommand.Parameters.AddWithValue("@PeriodEndingDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().PeriodEndingDate);
                //            Updatecommand.Parameters.AddWithValue("@FileDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().FileDate);
                //            Updatecommand.Parameters.AddWithValue("@StatementType", objProfitability.ProfitabilityEntityList.FirstOrDefault().StatementType);
                //            Updatecommand.Parameters.AddWithValue("@DataType", objProfitability.ProfitabilityEntityList.FirstOrDefault().DataType);
                //            Updatecommand.Parameters.AddWithValue("@CurrencyId", objProfitability.ProfitabilityEntityList.FirstOrDefault().CurrencyId);
                //            Updatecommand.Parameters.AddWithValue("@FiscalYearEnd", objProfitability.ProfitabilityEntityList.FirstOrDefault().FiscalYearEnd);
                //            Updatecommand.Parameters.AddWithValue("@GrossMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().GrossMargin);
                //            Updatecommand.Parameters.AddWithValue("@OperatingMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().OperatingMargin);
                //            Updatecommand.Parameters.AddWithValue("@EBTMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBTMargin);
                //            Updatecommand.Parameters.AddWithValue("@TaxRate", objProfitability.ProfitabilityEntityList.FirstOrDefault().TaxRate);
                //            Updatecommand.Parameters.AddWithValue("@NetMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetMargin);
                //            Updatecommand.Parameters.AddWithValue("@SalesPerEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().SalesPerEmployee);
                //            Updatecommand.Parameters.AddWithValue("@EBITMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITMargin);
                //            Updatecommand.Parameters.AddWithValue("@EBITDAMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITDAMargin);
                //            Updatecommand.Parameters.AddWithValue("@NormalizedNetProfitMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NormalizedNetProfitMargin);
                //            Updatecommand.Parameters.AddWithValue("@InterestCoverage", objProfitability.ProfitabilityEntityList.FirstOrDefault().InterestCoverage);
                //            Updatecommand.Parameters.AddWithValue("@IncPerEmployeeTotOps", objProfitability.ProfitabilityEntityList.FirstOrDefault().IncPerEmployeeTotOps);
                //            Updatecommand.Parameters.AddWithValue("@AccessionNumber", objProfitability.ProfitabilityEntityList.FirstOrDefault().AccessionNumber);
                //            Updatecommand.Parameters.AddWithValue("@FormType", objProfitability.ProfitabilityEntityList.FirstOrDefault().FormType);
                //            Updatecommand.Parameters.AddWithValue("@NetIncomeperFullTimeEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetIncomeperFullTimeEmployee);
                //            connection.Open();
                //            int result = Updatecommand.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //    else
                //    {
                //        String query = "INSERT INTO dbo.ProfitabilityRatios (Symbol,ReportDate,PeriodEndingDate,FileDate,StatementType,DataType,CurrencyId,FiscalYearEnd,GrossMargin,OperatingMargin,EBTMargin,TaxRate,NetMargin,SalesPerEmployee,EBITMargin,EBITDAMargin,NormalizedNetProfitMargin,InterestCoverage,IncPerEmployeeTotOps,AccessionNumber,FormType,NetIncomeperFullTimeEmployee) VALUES (@Symbol,@ReportDate,@PeriodEndingDate,@FileDate,@StatementType,@DataType,@CurrencyId,@FiscalYearEnd,@GrossMargin,@OperatingMargin,@EBTMargin,@TaxRate,@NetMargin,@SalesPerEmployee,@EBITMargin,@EBITDAMargin,@NormalizedNetProfitMargin,@InterestCoverage,@IncPerEmployeeTotOps,@AccessionNumber,@FormType,@NetIncomeperFullTimeEmployee)";
                //        using (SqlCommand command = new SqlCommand(query, connection))
                //        {
                //            command.Parameters.AddWithValue("@Symbol", objProfitability.GeneralInfo.Symbol);
                //            command.Parameters.AddWithValue("@ReportDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().ReportDate);
                //            command.Parameters.AddWithValue("@PeriodEndingDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().PeriodEndingDate);
                //            command.Parameters.AddWithValue("@FileDate", objProfitability.ProfitabilityEntityList.FirstOrDefault().FileDate);
                //            command.Parameters.AddWithValue("@StatementType", objProfitability.ProfitabilityEntityList.FirstOrDefault().StatementType);
                //            command.Parameters.AddWithValue("@DataType", objProfitability.ProfitabilityEntityList.FirstOrDefault().DataType);
                //            command.Parameters.AddWithValue("@CurrencyId", objProfitability.ProfitabilityEntityList.FirstOrDefault().CurrencyId);
                //            command.Parameters.AddWithValue("@FiscalYearEnd", objProfitability.ProfitabilityEntityList.FirstOrDefault().FiscalYearEnd);
                //            command.Parameters.AddWithValue("@GrossMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().GrossMargin);
                //            command.Parameters.AddWithValue("@OperatingMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().OperatingMargin);
                //            command.Parameters.AddWithValue("@EBTMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBTMargin);
                //            command.Parameters.AddWithValue("@TaxRate", objProfitability.ProfitabilityEntityList.FirstOrDefault().TaxRate);
                //            command.Parameters.AddWithValue("@NetMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetMargin);
                //            command.Parameters.AddWithValue("@SalesPerEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().SalesPerEmployee);
                //            command.Parameters.AddWithValue("@EBITMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITMargin);
                //            command.Parameters.AddWithValue("@EBITDAMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().EBITDAMargin);
                //            command.Parameters.AddWithValue("@NormalizedNetProfitMargin", objProfitability.ProfitabilityEntityList.FirstOrDefault().NormalizedNetProfitMargin);
                //            command.Parameters.AddWithValue("@InterestCoverage", objProfitability.ProfitabilityEntityList.FirstOrDefault().InterestCoverage);
                //            command.Parameters.AddWithValue("@IncPerEmployeeTotOps", objProfitability.ProfitabilityEntityList.FirstOrDefault().IncPerEmployeeTotOps);
                //            command.Parameters.AddWithValue("@AccessionNumber", objProfitability.ProfitabilityEntityList.FirstOrDefault().AccessionNumber);
                //            command.Parameters.AddWithValue("@FormType", objProfitability.ProfitabilityEntityList.FirstOrDefault().FormType);
                //            command.Parameters.AddWithValue("@NetIncomeperFullTimeEmployee", objProfitability.ProfitabilityEntityList.FirstOrDefault().NetIncomeperFullTimeEmployee);
                //            connection.Open();
                //            int result = command.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void InsertUpdateEfficiencyRatios(EfficiencyRatios objEfficiencyRatios, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.EfficiencyRatio>(objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.EfficiencyRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.EfficiencyRatios.Add(result);
                    }
                    else
                    {
                        context.EfficiencyRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.EfficiencyRatios.Add(result);

                    context.SaveChanges();

                }
                //using (SqlConnection connection = new SqlConnection(connstring))
                //{
                //    SqlCommand CmdRecordExist = new SqlCommand("SELECT COUNT(*) FROM dbo.EfficiencyRatios WHERE ([Symbol] = @Symbol)", connection);
                //    CmdRecordExist.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //    connection.Open();
                //    int RecordExist = (int)CmdRecordExist.ExecuteScalar();
                //    connection.Close();
                //    if (RecordExist > 0)
                //    {
                //        String UpdateQuery = "Update dbo.EfficiencyRatios set Symbol = @Symbol,ReportDate = @ReportDate,PeriodEndingDate =@PeriodEndingDate,FileDate =@FileDate,StatementType =@StatementType,DataType=@DataType,Interim=@Interim,FiscalYearEnd =@FiscalYearEnd,DaysInSales=@DaysInSales,DaysInInventory=@DaysInInventory,DaysInPayment =@DaysInPayment,CashConversionCycle=@CashConversionCycle,ReceivableTurnover=@ReceivableTurnover,InventoryTurnover=@InventoryTurnover,PayableTurnover=@PayableTurnover,FixedAssetsTurnover=@FixedAssetsTurnover,AssetsTurnover=@AssetsTurnover,ROE=@ROE,ROA=@ROA,ROIC=@ROIC,FCFSalesRatio=@FCFSalesRatio,AccessionNumber=@AccessionNumber,FormType=@FormType,ROE5YrAvg=@ROE5YrAvg,ROA5YrAvg=@ROA5YrAvg,AVG5YrsROIC=@AVG5YrsROIC,NormalizedROIC=@NormalizedROIC where Symbol = @Symbol";
                //        using (SqlCommand Updatecommand = new SqlCommand(UpdateQuery, connection))
                //        {
                //            Updatecommand.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //            Updatecommand.Parameters.AddWithValue("@ReportDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReportDate);
                //            Updatecommand.Parameters.AddWithValue("@PeriodEndingDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PeriodEndingDate);
                //            Updatecommand.Parameters.AddWithValue("@FileDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FileDate);
                //            Updatecommand.Parameters.AddWithValue("@StatementType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().StatementType);
                //            Updatecommand.Parameters.AddWithValue("@DataType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DataType);
                //            Updatecommand.Parameters.AddWithValue("@Interim", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().Interim);
                //            Updatecommand.Parameters.AddWithValue("@FiscalYearEnd", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FiscalYearEnd);
                //            Updatecommand.Parameters.AddWithValue("@DaysInSales", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInSales);
                //            Updatecommand.Parameters.AddWithValue("@DaysInInventory", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInInventory);
                //            Updatecommand.Parameters.AddWithValue("@DaysInPayment", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInPayment);
                //            Updatecommand.Parameters.AddWithValue("@CashConversionCycle", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().CashConversionCycle);
                //            Updatecommand.Parameters.AddWithValue("@ReceivableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReceivableTurnover);
                //            Updatecommand.Parameters.AddWithValue("@InventoryTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().InventoryTurnover);
                //            Updatecommand.Parameters.AddWithValue("@PayableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PayableTurnover);
                //            Updatecommand.Parameters.AddWithValue("@FixedAssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FixedAssetsTurnover);
                //            Updatecommand.Parameters.AddWithValue("@AssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AssetsTurnover);
                //            Updatecommand.Parameters.AddWithValue("@ROE", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE);
                //            Updatecommand.Parameters.AddWithValue("@ROA", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA);
                //            Updatecommand.Parameters.AddWithValue("@ROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROIC);
                //            Updatecommand.Parameters.AddWithValue("@FCFSalesRatio", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FCFSalesRatio);
                //            Updatecommand.Parameters.AddWithValue("@AccessionNumber", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AccessionNumber);
                //            Updatecommand.Parameters.AddWithValue("@FormType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FormType);
                //            Updatecommand.Parameters.AddWithValue("@ROE5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE5YrAvg);
                //            Updatecommand.Parameters.AddWithValue("@ROA5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA5YrAvg);
                //            Updatecommand.Parameters.AddWithValue("@AVG5YrsROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AVG5YrsROIC);
                //            Updatecommand.Parameters.AddWithValue("@NormalizedROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().NormalizedROIC);
                //            connection.Open();
                //            int result = Updatecommand.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //    else
                //    {
                //        String query = "INSERT INTO dbo.EfficiencyRatios (Symbol,ReportDate,PeriodEndingDate,FileDate,StatementType,DataType,Interim,FiscalYearEnd,DaysInSales,DaysInInventory,DaysInPayment,CashConversionCycle,ReceivableTurnover,InventoryTurnover,PayableTurnover,FixedAssetsTurnover,AssetsTurnover,ROE,ROA,ROIC,FCFSalesRatio,AccessionNumber,FormType,ROE5YrAvg,ROA5YrAvg,AVG5YrsROIC,NormalizedROIC) VALUES (@Symbol,@ReportDate,@PeriodEndingDate,@FileDate,@StatementType,@DataType,@Interim,@FiscalYearEnd,@DaysInSales,@DaysInInventory,@DaysInPayment,@CashConversionCycle,@ReceivableTurnover,@InventoryTurnover,@PayableTurnover,@FixedAssetsTurnover,@AssetsTurnover,@ROE,@ROA,@ROIC,@FCFSalesRatio,@AccessionNumber,@FormType,@ROE5YrAvg,@ROA5YrAvg,@AVG5YrsROIC,@NormalizedROIC)";
                //        using (SqlCommand command = new SqlCommand(query, connection))
                //        {
                //            command.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //            command.Parameters.AddWithValue("@ReportDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReportDate);
                //            command.Parameters.AddWithValue("@PeriodEndingDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PeriodEndingDate);
                //            command.Parameters.AddWithValue("@FileDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FileDate);
                //            command.Parameters.AddWithValue("@StatementType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().StatementType);
                //            command.Parameters.AddWithValue("@DataType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DataType);
                //            command.Parameters.AddWithValue("@Interim", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().Interim);
                //            command.Parameters.AddWithValue("@FiscalYearEnd", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FiscalYearEnd);
                //            command.Parameters.AddWithValue("@DaysInSales", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInSales);
                //            command.Parameters.AddWithValue("@DaysInInventory", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInInventory);
                //            command.Parameters.AddWithValue("@DaysInPayment", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInPayment);
                //            command.Parameters.AddWithValue("@CashConversionCycle", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().CashConversionCycle);
                //            command.Parameters.AddWithValue("@ReceivableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReceivableTurnover);
                //            command.Parameters.AddWithValue("@InventoryTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().InventoryTurnover);
                //            command.Parameters.AddWithValue("@PayableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PayableTurnover);
                //            command.Parameters.AddWithValue("@FixedAssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FixedAssetsTurnover);
                //            command.Parameters.AddWithValue("@AssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AssetsTurnover);
                //            command.Parameters.AddWithValue("@ROE", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE);
                //            command.Parameters.AddWithValue("@ROA", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA);
                //            command.Parameters.AddWithValue("@ROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROIC);
                //            command.Parameters.AddWithValue("@FCFSalesRatio", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FCFSalesRatio);
                //            command.Parameters.AddWithValue("@AccessionNumber", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AccessionNumber);
                //            command.Parameters.AddWithValue("@FormType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FormType);
                //            command.Parameters.AddWithValue("@ROE5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE5YrAvg);
                //            command.Parameters.AddWithValue("@ROA5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA5YrAvg);
                //            command.Parameters.AddWithValue("@AVG5YrsROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AVG5YrsROIC);
                //            command.Parameters.AddWithValue("@NormalizedROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().NormalizedROIC);
                //            connection.Open();
                //            int result = command.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void InsertUpdateEfficiencyRatiosTTM(EfficiencyRatios objEfficiencyRatios, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.EfficiencyRatio>(objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.EfficiencyRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.EfficiencyRatios.Add(result);
                    }
                    else
                    {
                        context.EfficiencyRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.EfficiencyRatios.Add(result);

                    context.SaveChanges();

                }
                //using (SqlConnection connection = new SqlConnection(connstring))
                //{
                //    SqlCommand CmdRecordExist = new SqlCommand("SELECT COUNT(*) FROM dbo.EfficiencyRatiosTTM WHERE ([Symbol] = @Symbol)", connection);
                //    CmdRecordExist.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //    connection.Open();
                //    int RecordExist = (int)CmdRecordExist.ExecuteScalar();
                //    connection.Close();
                //    if (RecordExist > 0)
                //    {
                //        String UpdateQuery = "Update dbo.EfficiencyRatiosTTM set Symbol = @Symbol,ReportDate = @ReportDate,PeriodEndingDate =@PeriodEndingDate,FileDate =@FileDate,StatementType =@StatementType,DataType=@DataType,Interim=@Interim,FiscalYearEnd =@FiscalYearEnd,DaysInSales=@DaysInSales,DaysInInventory=@DaysInInventory,DaysInPayment =@DaysInPayment,CashConversionCycle=@CashConversionCycle,ReceivableTurnover=@ReceivableTurnover,InventoryTurnover=@InventoryTurnover,PayableTurnover=@PayableTurnover,FixedAssetsTurnover=@FixedAssetsTurnover,AssetsTurnover=@AssetsTurnover,ROE=@ROE,ROA=@ROA,ROIC=@ROIC,FCFSalesRatio=@FCFSalesRatio,AccessionNumber=@AccessionNumber,FormType=@FormType,ROE5YrAvg=@ROE5YrAvg,ROA5YrAvg=@ROA5YrAvg,AVG5YrsROIC=@AVG5YrsROIC,NormalizedROIC=@NormalizedROIC where Symbol = @Symbol";
                //        using (SqlCommand Updatecommand = new SqlCommand(UpdateQuery, connection))
                //        {
                //            Updatecommand.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //            Updatecommand.Parameters.AddWithValue("@ReportDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReportDate);
                //            Updatecommand.Parameters.AddWithValue("@PeriodEndingDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PeriodEndingDate);
                //            Updatecommand.Parameters.AddWithValue("@FileDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FileDate);
                //            Updatecommand.Parameters.AddWithValue("@StatementType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().StatementType);
                //            Updatecommand.Parameters.AddWithValue("@DataType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DataType);
                //            Updatecommand.Parameters.AddWithValue("@Interim", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().Interim);
                //            Updatecommand.Parameters.AddWithValue("@FiscalYearEnd", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FiscalYearEnd);
                //            Updatecommand.Parameters.AddWithValue("@DaysInSales", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInSales);
                //            Updatecommand.Parameters.AddWithValue("@DaysInInventory", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInInventory);
                //            Updatecommand.Parameters.AddWithValue("@DaysInPayment", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInPayment);
                //            Updatecommand.Parameters.AddWithValue("@CashConversionCycle", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().CashConversionCycle);
                //            Updatecommand.Parameters.AddWithValue("@ReceivableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReceivableTurnover);
                //            Updatecommand.Parameters.AddWithValue("@InventoryTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().InventoryTurnover);
                //            Updatecommand.Parameters.AddWithValue("@PayableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PayableTurnover);
                //            Updatecommand.Parameters.AddWithValue("@FixedAssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FixedAssetsTurnover);
                //            Updatecommand.Parameters.AddWithValue("@AssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AssetsTurnover);
                //            Updatecommand.Parameters.AddWithValue("@ROE", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE);
                //            Updatecommand.Parameters.AddWithValue("@ROA", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA);
                //            Updatecommand.Parameters.AddWithValue("@ROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROIC);
                //            Updatecommand.Parameters.AddWithValue("@FCFSalesRatio", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FCFSalesRatio);
                //            Updatecommand.Parameters.AddWithValue("@AccessionNumber", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AccessionNumber);
                //            Updatecommand.Parameters.AddWithValue("@FormType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FormType);
                //            Updatecommand.Parameters.AddWithValue("@ROE5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE5YrAvg);
                //            Updatecommand.Parameters.AddWithValue("@ROA5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA5YrAvg);
                //            Updatecommand.Parameters.AddWithValue("@AVG5YrsROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AVG5YrsROIC);
                //            Updatecommand.Parameters.AddWithValue("@NormalizedROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().NormalizedROIC);
                //            connection.Open();
                //            int result = Updatecommand.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }
                //    }
                //    else
                //    {
                //        String query = "INSERT INTO dbo.EfficiencyRatiosTTM (Symbol,ReportDate,PeriodEndingDate,FileDate,StatementType,DataType,Interim,FiscalYearEnd,DaysInSales,DaysInInventory,DaysInPayment,CashConversionCycle,ReceivableTurnover,InventoryTurnover,PayableTurnover,FixedAssetsTurnover,AssetsTurnover,ROE,ROA,ROIC,FCFSalesRatio,AccessionNumber,FormType,ROE5YrAvg,ROA5YrAvg,AVG5YrsROIC,NormalizedROIC) VALUES (@Symbol,@ReportDate,@PeriodEndingDate,@FileDate,@StatementType,@DataType,@Interim,@FiscalYearEnd,@DaysInSales,@DaysInInventory,@DaysInPayment,@CashConversionCycle,@ReceivableTurnover,@InventoryTurnover,@PayableTurnover,@FixedAssetsTurnover,@AssetsTurnover,@ROE,@ROA,@ROIC,@FCFSalesRatio,@AccessionNumber,@FormType,@ROE5YrAvg,@ROA5YrAvg,@AVG5YrsROIC,@NormalizedROIC)";
                //        using (SqlCommand command = new SqlCommand(query, connection))
                //        {
                //            command.Parameters.AddWithValue("@Symbol", objEfficiencyRatios.GeneralInfo.Symbol);
                //            command.Parameters.AddWithValue("@ReportDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReportDate);
                //            command.Parameters.AddWithValue("@PeriodEndingDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PeriodEndingDate);
                //            command.Parameters.AddWithValue("@FileDate", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FileDate);
                //            command.Parameters.AddWithValue("@StatementType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().StatementType);
                //            command.Parameters.AddWithValue("@DataType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DataType);
                //            command.Parameters.AddWithValue("@Interim", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().Interim);
                //            command.Parameters.AddWithValue("@FiscalYearEnd", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FiscalYearEnd);
                //            command.Parameters.AddWithValue("@DaysInSales", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInSales);
                //            command.Parameters.AddWithValue("@DaysInInventory", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInInventory);
                //            command.Parameters.AddWithValue("@DaysInPayment", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().DaysInPayment);
                //            command.Parameters.AddWithValue("@CashConversionCycle", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().CashConversionCycle);
                //            command.Parameters.AddWithValue("@ReceivableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ReceivableTurnover);
                //            command.Parameters.AddWithValue("@InventoryTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().InventoryTurnover);
                //            command.Parameters.AddWithValue("@PayableTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().PayableTurnover);
                //            command.Parameters.AddWithValue("@FixedAssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FixedAssetsTurnover);
                //            command.Parameters.AddWithValue("@AssetsTurnover", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AssetsTurnover);
                //            command.Parameters.AddWithValue("@ROE", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE);
                //            command.Parameters.AddWithValue("@ROA", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA);
                //            command.Parameters.AddWithValue("@ROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROIC);
                //            command.Parameters.AddWithValue("@FCFSalesRatio", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FCFSalesRatio);
                //            command.Parameters.AddWithValue("@AccessionNumber", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AccessionNumber);
                //            command.Parameters.AddWithValue("@FormType", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().FormType);
                //            command.Parameters.AddWithValue("@ROE5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROE5YrAvg);
                //            command.Parameters.AddWithValue("@ROA5YrAvg", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().ROA5YrAvg);
                //            command.Parameters.AddWithValue("@AVG5YrsROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().AVG5YrsROIC);
                //            command.Parameters.AddWithValue("@NormalizedROIC", objEfficiencyRatios.EfficiencyEntityList.FirstOrDefault().NormalizedROIC);
                //            connection.Open();
                //            int result = command.ExecuteNonQuery();

                //            if (result < 0)
                //                Console.WriteLine("Error inserting data into Database!");
                //        }


                //    }
                //}
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void InsertUpdateFinancialHealthRatios(FinancialHealthRatioModel objFinancialHealthRatio, string connstring)
        {
            try
            {
                var result = AutoMapper.Mapper.Map<FinCurate.FinancialHealthRatio>(objFinancialHealthRatio.FinancialHealthEntityList.FirstOrDefault());
                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.FinancialHealthRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.FinancialHealthRatios.Add(result);
                    }
                    else
                    {
                        context.FinancialHealthRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.FinancialHealthRatios.Add(result);

                    context.SaveChanges();

                }
          
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void InsertUpdateReturnStatistics(ReturnStatistics objReturnStatistics, string connstring)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connstring))
                {
                    SqlCommand CmdRecordExist = new SqlCommand("SELECT COUNT(*) FROM dbo.ReturnStatistics WHERE ([Symbol] = @Symbol)", connection);
                    CmdRecordExist.Parameters.AddWithValue("@Symbol", objReturnStatistics.GeneralInfo.Symbol);
                    connection.Open();
                    int RecordExist = (int)CmdRecordExist.ExecuteScalar();
                    connection.Close();
                    if (RecordExist > 0)
                    {
                        String UpdateQuery = "Update dbo.ReturnStatistics set Symbol = @Symbol,AsOfDate = @AsOfDate,NumberOfMonths =@NumberOfMonths,Mean =@Mean,StandardDeviation =@StandardDeviation,Best3MonthReturn=@Best3MonthReturn,Alpha =@Alpha,Beta =@Beta,RSquare=@RSquare where Symbol = @Symbol";
                        using (SqlCommand Updatecommand = new SqlCommand(UpdateQuery, connection))
                        {
                            Updatecommand.Parameters.AddWithValue("@Symbol", objReturnStatistics.GeneralInfo.Symbol);
                            Updatecommand.Parameters.AddWithValue("@AsOfDate", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().AsOfDate);
                            Updatecommand.Parameters.AddWithValue("@NumberOfMonths", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().NumberOfMonths);
                            Updatecommand.Parameters.AddWithValue("@Mean", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Mean);
                            Updatecommand.Parameters.AddWithValue("@StandardDeviation", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().StandardDeviation);
                            Updatecommand.Parameters.AddWithValue("@Best3MonthReturn", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Best3MonthReturn);
                            Updatecommand.Parameters.AddWithValue("@Worst3MonthReturn", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Worst3MonthReturn);
                            Updatecommand.Parameters.AddWithValue("@Alpha", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Alpha);
                            Updatecommand.Parameters.AddWithValue("@Beta", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Beta);
                            Updatecommand.Parameters.AddWithValue("@RSquare", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().RSquare);
                            connection.Open();
                            int result = Updatecommand.ExecuteNonQuery();

                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                    else
                    {
                        String query = "INSERT INTO dbo.ReturnStatistics (Symbol,AsOfDate,NumberOfMonths,Mean,StandardDeviation,Best3MonthReturn,Worst3MonthReturn,Alpha,Beta,RSquare) VALUES (@Symbol,@AsOfDate,@NumberOfMonths,@Mean,@StandardDeviation,@Best3MonthReturn,@Alpha,@Beta,@RSquare)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Symbol", objReturnStatistics.GeneralInfo.Symbol);
                            command.Parameters.AddWithValue("@AsOfDate", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().AsOfDate);
                            command.Parameters.AddWithValue("@NumberOfMonths", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().NumberOfMonths);
                            command.Parameters.AddWithValue("@Mean", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Mean);
                            command.Parameters.AddWithValue("@StandardDeviation", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().StandardDeviation);
                            command.Parameters.AddWithValue("@Best3MonthReturn", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Best3MonthReturn);
                            command.Parameters.AddWithValue("@Worst3MonthReturn", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Worst3MonthReturn);
                            command.Parameters.AddWithValue("@Alpha", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Alpha);
                            command.Parameters.AddWithValue("@Beta", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Beta);
                            command.Parameters.AddWithValue("@RSquare", objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().RSquare);
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void InsertUpdateValuationRatios(ValuationRatios objValuationRatios, string connstring)
        {
            try
            {

                var result = AutoMapper.Mapper.Map<FinCurate.ValuationRatio>(objValuationRatios.valuationRatioEntityList.FirstOrDefault());

                using (FincurateEntities context = new FincurateEntities())
                {
                    var IsExisting = context.ValuationRatios.Where(m => m.Symbol == result.Symbol).FirstOrDefault();
                    if (IsExisting == null)
                    {
                        context.ValuationRatios.Add(result);
                    }
                    else
                    {
                        context.ValuationRatios.Remove(IsExisting);
                        context.SaveChanges();
                    }
                    context.ValuationRatios.Add(result);

                    context.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

    }
}