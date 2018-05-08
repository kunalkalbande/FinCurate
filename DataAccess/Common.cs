using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using CommonLibrary.Models;
using Newtonsoft.Json;

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


        public static ProfitabilityRatios GetFinancialKeyRatiosService(string token)
        {
            string result = null;
            string category = "GetProfitabilityRatios";
            string exchangeId = "NYS";
            string identifier = "MSFT";
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

                if (objProfitability != null && objProfitability.ProfitabilityEntityList.Count > 0)
                {
                    return objProfitability;

                }
            }
            catch (Exception e)
            {

            }

            return objProfitability;
        }


    }
}
