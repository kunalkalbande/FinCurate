using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using CommonLibrary.Models;
using Newtonsoft.Json;
using System.Linq;

namespace CommonLibrary
{
   public class Common
    {

        private static string LoginURL = "https://equityapi.morningstar.com/WSLogin/Login.asmx/Login?email={0}&password={1}";
        private static string BalanceSheetURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetProfitabilityRatios?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";

        public static TokenEntity Login(string email, string password)
        {
            string sURL = string.Format(LoginURL, email, password);
            string loginResult = GetResultByURL(sURL);
            if (string.IsNullOrEmpty(loginResult))
                return null;

            TokenEntity tokenEntity = GetTokenEntity(loginResult);
            return tokenEntity;

        }

        private static TokenEntity GetTokenEntity(string loginResult)
        {
            TokenEntity token = null;
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(System.Text.RegularExpressions.Regex.Replace(loginResult, @"(xmlns:?[^=]*=[""][^""]*[""])", "", RegexOptions.IgnoreCase | RegexOptions.Multiline));
                token = new TokenEntity();
                token.IsSuccess = doc.SelectSingleNode(@"//TokenEntity/IsSuccess").InnerText == "true" ? true : false;
                token.Token = doc.SelectSingleNode(@"//TokenEntity/Token").InnerText;
                token.expireDate = DateTime.ParseExact(doc.SelectSingleNode(@"//TokenEntity/expireDate").InnerText, "yyyy-MM-ddTHH:mm:ss.fffffffZ", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Error for parse response string=" + loginResult);
                //Console.WriteLine(e);
            }
            return token;
        }

        private static string GetResultByURL(string url)
        {
            HttpWebRequest request = null;
            Stream responseStream = null;
            StreamReader outSr = null;
            HttpWebResponse response = null;
            string sRet = null;
            try
            {
                string sXML = null;
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                responseStream = response.GetResponseStream();
                outSr = new StreamReader(responseStream);

                sXML = outSr.ReadToEnd();
                if (sXML != null)
                {
                    sRet = sXML;
                    return sXML;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("ERROR on this url=" + url);
                Console.WriteLine(ex);
            }
            finally
            {
                if (request != null)
                    request.Abort();
                if (response != null)
                    response.Close();
                if (outSr != null)
                    outSr.Close();
                if (responseStream != null)
                    responseStream.Close();
            }

            return sRet;
        }

        #region FinancialKeyRatios
        public static ProfitabilityRatios GetFinancialKeyRatiosService(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetProfitabilityRatios";
            string exchangeId = apiRequest.exchangeId; //"NAS";
            string identifier = apiRequest.identifier; //"MSFT";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            ProfitabilityRatios objProfitability = new ProfitabilityRatios();
            string sURL = string.Format(BalanceSheetURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);

            result = GetResultByURL(sURL);
            try
            {
                objProfitability = JsonConvert.DeserializeObject<ProfitabilityRatios>(result);
                objProfitability.ProfitabilityEntityList.FirstOrDefault().Symbol = objProfitability.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objProfitability;
        }

        public static ProfitabilityRatios GetProfitabilityRatiosTTM(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetProfitabilityRatiosTTM";
            string exchangeId = apiRequest.exchangeId;// "NAS";
            string identifier = apiRequest.identifier;// "MSFT";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string URL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetProfitabilityRatiosTTM?category={0}&exchangeId={1}&identifier={2}startDate={3}&endDate={4}&identifierType={5}&responseType={6}&Token={7}";
            ProfitabilityRatios objProfitability = new ProfitabilityRatios();
            string sURL = string.Format(URL, category, exchangeId, identifier, startDate, endDate, identifierType, responseType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objProfitability = JsonConvert.DeserializeObject<ProfitabilityRatios>(result);
                objProfitability.ProfitabilityEntityList.FirstOrDefault().Symbol = objProfitability.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objProfitability;
        }

        public static EfficiencyRatios GetEfficiencyRatios(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetEfficiencyRatios";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string EfficiencyRatiosURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetEfficiencyRatios?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            string sURL = string.Format(EfficiencyRatiosURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objEfficiencyRatios = JsonConvert.DeserializeObject<EfficiencyRatios>(result);
            }
            catch (Exception e)
            {
                throw;
            }

            return objEfficiencyRatios;
        }

        public static EfficiencyRatios GetEfficiencyRatiosTTM(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetEfficiencyRatiosTTM";
            string exchangeId = apiRequest.exchangeId;//"NYS";
            string identifier = apiRequest.identifier;//"IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string EfficiencyRatiosTTMURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetEfficiencyRatiosTTM?category={0}&exchangeId={1}&identifier=IBM&startDate={3}&endDate={4}&identifierType={5}&responseType={6}&Token={7}";
            EfficiencyRatios objEfficiencyRatios = new EfficiencyRatios();
            string sURL = string.Format(EfficiencyRatiosTTMURL, category, exchangeId, identifier, startDate, endDate, identifierType, responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objEfficiencyRatios = JsonConvert.DeserializeObject<EfficiencyRatios>(result);
            }
            catch (Exception e)
            {
                throw;
            }

            return objEfficiencyRatios;
        }

        public static FinancialHealthRatioModel GetFinancialHealthRatios(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetFinancialHealthRatios";
            string exchangeId = apiRequest.exchangeId;//"NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string Token = token;
            string FinancialHealthRatioURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetFinancialHealthRatios?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            FinancialHealthRatioModel objFinancialHealthRatio = new FinancialHealthRatioModel();
            string sURL = string.Format(FinancialHealthRatioURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objFinancialHealthRatio = JsonConvert.DeserializeObject<FinancialHealthRatioModel>(result);
                objFinancialHealthRatio.FinancialHealthEntityList.FirstOrDefault().Symbol = objFinancialHealthRatio.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objFinancialHealthRatio;
        }

        public static ValuationRatios GetValuationRatios(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetValuationRatios";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier; //"IBM";
            string identifierType = "Symbol";
            string period = "Snapshot";
            string responseType = "JSON";
            string Token = token;
            string ValuationRatiosURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetValuationRatios?category={0}&exchangeId={1}&identifier={2}&identifierType={3}&period={4}&responseType={5}&Token={6}";
            ValuationRatios objValuationRatios = new ValuationRatios();
            string sURL = string.Format(ValuationRatiosURL, category, exchangeId, identifier, identifierType, period, responseType, Token);

            result = GetResultByURL(sURL);
            try
            {
                objValuationRatios = JsonConvert.DeserializeObject<ValuationRatios>(result);
                objValuationRatios.valuationRatioEntityList.FirstOrDefault().Symbol = objValuationRatios.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objValuationRatios;
        }


        public static GrowthRatiosModel GetGrowthRatios(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetGrowthRatios";
            string exchangeId = apiRequest.exchangeId; //"NAS";
            string identifier = apiRequest.identifier; //"MSFT";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string GrowthRatiosURL = "http://equityapi.morningstar.com/WebService/FinancialKeyRatiosService.asmx/GetGrowthRatios?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            GrowthRatiosModel objGrowthRatios = new GrowthRatiosModel();
            string sURL = string.Format(GrowthRatiosURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);

            result = GetResultByURL(sURL);
            try
            {
                objGrowthRatios = JsonConvert.DeserializeObject<GrowthRatiosModel>(result);
                objGrowthRatios.GrowthEntityList.FirstOrDefault().Symbol = objGrowthRatios.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objGrowthRatios;
        }
        #endregion

        #region CompanyFinancial
        public static CompanyFinancials GetCompanyFinancialAvailability(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetCompanyFinancialAvailabilityList";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string CompanyFinancialAvailabilityURL = "http://equityapi.morningstar.com/WebService/GlobalMasterListsService.asmx/GetCompanyFinancialAvailabilityList?category={0}&exchangeId={1}&identifier={2}&responseType={3}&identifierType={4}&Token={5}";
            CompanyFinancials objCompanyFinancials = new CompanyFinancials();
            string sURL = string.Format(CompanyFinancialAvailabilityURL, category, exchangeId, identifier, responseType, identifierType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objCompanyFinancials = JsonConvert.DeserializeObject<CompanyFinancials>(result);
            }
            catch (Exception e)
            {
                throw;
            }

            return objCompanyFinancials;
        }

        public static BalanceSheetModel GetBalanceSheet(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetBalanceSheet";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string BalanceSheetURL = "http://equityapi.morningstar.com/WebService/CompanyFinancialsService.asmx/GetBalanceSheet?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            BalanceSheetModel objBalanceSheet = new BalanceSheetModel();
            string sURL = string.Format(BalanceSheetURL, category, exchangeId, identifier,startDate, endDate, identifierType,statementType, dataType,responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objBalanceSheet = JsonConvert.DeserializeObject<BalanceSheetModel>(result);
                objBalanceSheet.BalanceSheetEntityList.FirstOrDefault().Symbol = objBalanceSheet.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objBalanceSheet;
        }

        public static CashFlowModel GetCashFlow(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetCashFlow";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Quarterly";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string CashFlowURL = "http://equityapi.morningstar.com/WebService/CompanyFinancialsService.asmx/GetCashFlow?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            CashFlowModel objCashFlow = new CashFlowModel();
            string sURL = string.Format(CashFlowURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objCashFlow = JsonConvert.DeserializeObject<CashFlowModel>(result);
                objCashFlow.CashFlowEntityList.FirstOrDefault().Symbol = objCashFlow.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objCashFlow;
        }

        public static CashFlowModel GetCashFlowTTM(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetCashFlowTTM";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2018";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string GetCashFlowTTMURL = "http://equityapi.morningstar.com/WebService/CompanyFinancialsService.asmx/GetCashFlowTTM?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&responseType={6}&Token={7}";
            CashFlowModel objCashFlow = new CashFlowModel();
            string sURL = string.Format(GetCashFlowTTMURL, category, exchangeId, identifier, startDate, endDate, identifierType, responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objCashFlow = JsonConvert.DeserializeObject<CashFlowModel>(result);
                objCashFlow.CashFlowEntityList.FirstOrDefault().Symbol = objCashFlow.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objCashFlow;
        }

        public static MiscellaneousInfoModel GetMiscellaneousInfos(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetMiscellaneousInfos";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "01/2016";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Annual";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string GetMiscellaneousInfosURL = "http://equityapi.morningstar.com/WebService/CompanyFinancialsService.asmx/GetMiscellaneousInfos?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            MiscellaneousInfoModel objMiscellaneousInfo = new MiscellaneousInfoModel();
            string sURL = string.Format(GetMiscellaneousInfosURL, category, exchangeId, identifier, startDate, endDate, identifierType,statementType,dataType, responseType, Token);

            result = GetResultByURL(sURL);
            try
            {
                objMiscellaneousInfo = JsonConvert.DeserializeObject<MiscellaneousInfoModel>(result);
                objMiscellaneousInfo.MiscellaneousInfoEntityList.FirstOrDefault().Symbol = objMiscellaneousInfo.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objMiscellaneousInfo;
        }

        public static IncomeStatementModel GetIncomeStatement(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetIncomeStatement";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string startDate = "05/2016";
            string endDate = "05/2018";
            string identifierType = "Symbol";
            string statementType = "Annual";
            string dataType = "AOR";
            string responseType = "JSON";
            string Token = token;
            string IncomeStatementURL = "http://equityapi.morningstar.com/WebService/CompanyFinancialsService.asmx/GetIncomeStatement?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&statementType={6}&dataType={7}&responseType={8}&Token={9}";
            IncomeStatementModel objIncomeStatement = new IncomeStatementModel();
            string sURL = string.Format(IncomeStatementURL, category, exchangeId, identifier, startDate, endDate, identifierType, statementType, dataType, responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objIncomeStatement = JsonConvert.DeserializeObject<IncomeStatementModel>(result);
                objIncomeStatement.IncomeStatementEntityList.FirstOrDefault().Symbol = objIncomeStatement.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objIncomeStatement;
        }
        #endregion

        #region MarketPerformance
        public static ReturnStatistics GetReturnStatistics(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetReturnStatistics";
            string exchangeId = apiRequest.exchangeId; //"NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string BalanceSheetURL = "http://equityapi.morningstar.com/WebService/MarketPerformanceService.asmx/GetReturnStatistics?category={0}&exchangeId={1}&identifier={2}&responseType={3}&identifierType={4}&Token={5}";
            ReturnStatistics objReturnStatistics = new ReturnStatistics();
            string sURL = string.Format(BalanceSheetURL, category, exchangeId, identifier, responseType, identifierType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objReturnStatistics = JsonConvert.DeserializeObject<ReturnStatistics>(result);
                objReturnStatistics.ReturnStatisticsEntityList.FirstOrDefault().Symbol = objReturnStatistics.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objReturnStatistics;
        }
        public static MarketCapitalizationModel GetCurrentMarketCapitalization(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetCurrentMarketCapitalization";
            string exchangeId = apiRequest.exchangeId;// "NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string MarketCapitalizationURL = "http://equityapi.morningstar.com/WebService/MarketPerformanceService.asmx/GetCurrentMarketCapitalization?category={0}&exchangeId={1}&identifier={2}&responseType={3}&identifierType={4}&Token={5}";
            MarketCapitalizationModel objMarketCapitalization = new MarketCapitalizationModel();
            string sURL = string.Format(MarketCapitalizationURL, category, exchangeId, identifier, responseType, identifierType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objMarketCapitalization = JsonConvert.DeserializeObject<MarketCapitalizationModel>(result);
                objMarketCapitalization.MarketCapitalizationEntityList.FirstOrDefault().Symbol = objMarketCapitalization.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objMarketCapitalization;
        }
        #endregion

        #region GlobalStockAnalysis
        public static SharesSnapshotModel GetSharesSnapshot(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetSharesSnapshot";
            string exchangeId = apiRequest.exchangeId; //"NYS";
            string identifier = apiRequest.identifier; //"IBM";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string SharesSnapshotURL = "http://equityapi.morningstar.com/WebService/GlobalStockAnalysisResearchService.asmx/GetSharesSnapshot?category={0}&exchangeId={1}&identifier={2}&responseType={3}&identifierType={4}&Token={5}";
            SharesSnapshotModel objSharesSnapshot = new SharesSnapshotModel();
            string sURL = string.Format(SharesSnapshotURL, category, exchangeId, identifier, responseType, identifierType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objSharesSnapshot = JsonConvert.DeserializeObject<SharesSnapshotModel>(result);
                objSharesSnapshot.sharesSnapshotEntity.Symbol = objSharesSnapshot.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objSharesSnapshot;
        }

        public static SharesHistoryModel GetSharesHistorys(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetSharesHistorys";
            string exchangeId = apiRequest.exchangeId; //"NYS";
            string identifier = apiRequest.identifier; //"IBM";
            string startDate = "05/09/2016";
            string endDate = "05/09/2018";
            string identifierType = "Symbol";
            string responseType = "JSON";
            string Token = token;
            string SharesHistorysURL = "http://equityapi.morningstar.com/WebService/GlobalStockAnalysisResearchService.asmx/GetSharesHistorys?category={0}&exchangeId={1}&identifier={2}&startDate={3}&endDate={4}&identifierType={5}&responseType={6}&Token={7}";
            SharesHistoryModel objSharesHistory = new SharesHistoryModel();
            string sURL = string.Format(SharesHistorysURL, category, exchangeId, identifier,startDate , endDate, identifierType, responseType, Token);

            result = GetResultByURL(sURL);

            try
            {
                objSharesHistory = JsonConvert.DeserializeObject<SharesHistoryModel>(result);
                objSharesHistory.SharesHistoryEntityList.FirstOrDefault().Symbol = objSharesHistory.GeneralInfo.Symbol;
            }
            catch (Exception e)
            {
                throw;
            }

            return objSharesHistory;
        }
        #endregion


        #region ExchangeCoverage
        public static StockExchangeSecurityModel GetStockExchangeSecurity(string token, APIRequest apiRequest)
        {
            string result = null;
            string category = "GetStockExchangeSecurityList";
            string exchangeId = apiRequest.exchangeId; //"NYS";
            string identifier = apiRequest.identifier;// "IBM";
            string identifierType = "Symbol";
            string stockStatus = "Active";
            string responseType = "JSON";
            string Token = token;
            string StockExchangeSecuritytURL = "http://equityapi.morningstar.com/WebService/GlobalMasterListsService.asmx/GetStockExchangeSecurityList?category={0}&exchangeId={1}&identifier={2}&identifierType={3}&stockStatus={4}&responseType={5}&Token={6}";
            StockExchangeSecurityModel objStockExchangeSecurity = new StockExchangeSecurityModel();
            string sURL = string.Format(StockExchangeSecuritytURL, category, exchangeId, identifier, identifierType,  stockStatus, responseType, Token);


            result = GetResultByURL(sURL);

            try
            {
                objStockExchangeSecurity = JsonConvert.DeserializeObject<StockExchangeSecurityModel>(result);
            }
            catch (Exception e)
            {
                throw;
            }

            return objStockExchangeSecurity;
        }
        #endregion

    }
}
