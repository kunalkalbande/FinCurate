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
        [HttpPost]
        public HttpResponseMessage PostProfitabilityRatios(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            ProfitabilityRatios objProfitability = new ProfitabilityRatios();
            objProfitability = Common.GetFinancialKeyRatiosService(tokenEntity.Token, apiRequest);
            if (objProfitability != null && objProfitability.MessageInfo.MessageCode.Equals(200))
            {
                bool result = InsertUpdateProfitabilityRatios(objProfitability, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        // GET api/<controller>/5
        [HttpPost]
        public HttpResponseMessage PostProfitabilityRatiosTTM(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {

            ProfitabilityRatios objProfitability = new ProfitabilityRatios();
            objProfitability = Common.GetProfitabilityRatiosTTM(tokenEntity.Token, apiRequest);
            if (objProfitability != null)
            {
                bool result = InsertUpdateProfitabilityRatiosTTM(objProfitability, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostEfficiencyRatios(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            objEfficiencyRatios = Common.GetEfficiencyRatios(tokenEntity.Token, apiRequest);
            if (objEfficiencyRatios != null)
            {
                bool result = InsertUpdateEfficiencyRatios(objEfficiencyRatios, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostEfficiencyRatiosTTM(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            objEfficiencyRatios = Common.GetEfficiencyRatiosTTM(tokenEntity.Token, apiRequest);
            if (objEfficiencyRatios != null)
            {
                bool result = InsertUpdateEfficiencyRatiosTTM(objEfficiencyRatios, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostFinancialHealthRatios(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            FinancialHealthRatioModel objFinancialHealthRatio = new FinancialHealthRatioModel();
            objFinancialHealthRatio = Common.GetFinancialHealthRatios(tokenEntity.Token, apiRequest);
            if (objFinancialHealthRatio != null)
            {
                bool result = InsertUpdateFinancialHealthRatios(objFinancialHealthRatio, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostReturnStatistics(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            Common.Login(email, Password);
            if (tokenEntity != null && tokenEntity.IsSuccess && tokenEntity.expireDate > DateTime.Now)
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
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        [HttpPost]
        public HttpResponseMessage PostValuationRatios(HttpRequestMessage request, [FromBody] APIRequest apiRequest)
        {
            ValuationRatios objValuationRatios = new ValuationRatios();
            objValuationRatios = Common.GetValuationRatios(tokenEntity.Token, apiRequest);
            if (objValuationRatios != null) //&& objValuationRatios.MessageInfo.MessageCode.Equals(200)
            {
                bool result = InsertUpdateValuationRatios(objValuationRatios, connstring);
                if (result)
                {
                    return request.CreateResponse(HttpStatusCode.OK, "Data is updated Sucessfully");
                }
            }
            return request.CreateResponse(HttpStatusCode.NotModified, "Unable to update data");
        }

        #region PrivateMethods

        private static bool InsertUpdateProfitabilityRatios(ProfitabilityRatios objProfitability, string connstring)
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
                return true;
            }
            catch (Exception)
            {

                return false;
                throw;
            }

        }

        private static bool InsertUpdateProfitabilityRatiosTTM(ProfitabilityRatios objProfitability, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        private static bool InsertUpdateEfficiencyRatios(EfficiencyRatios objEfficiencyRatios, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        private static bool InsertUpdateEfficiencyRatiosTTM(EfficiencyRatios objEfficiencyRatios, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        private static bool InsertUpdateFinancialHealthRatios(FinancialHealthRatioModel objFinancialHealthRatio, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        private static bool InsertUpdateReturnStatistics(ReturnStatistics objReturnStatistics, string connstring)
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
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        private static bool InsertUpdateValuationRatios(ValuationRatios objValuationRatios, string connstring)
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