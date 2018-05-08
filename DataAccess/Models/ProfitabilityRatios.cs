using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CommonLibrary.Models
{
    //[XmlRoot("Profitabilities")]
    //public class ProfitabilityRatios
    //{
    //    [XmlElement("ProfitabilityEntity")]
    //    public List<Profitability> Profitabilityes { get; set; }
    //}

    //public class Profitability
    //{
    //    public string CurrencyId { get; set; }
    //    public decimal GrossMargin { get; set; }
    //    public decimal OperatingMargin { get; set; }
    //    public decimal EBTMargin { get; set; }
    //    public decimal TaxRate { get; set; }
    //    public decimal NetMargin { get; set; }
    //    public decimal SalesPerEmployee { get; set; }
    //    public decimal EBITMargin { get; set; }
    //    public decimal EBITDAMargin { get; set; }
    //    public decimal NormalizedNetProfitMargin { get; set; }
    //    public decimal InterestCoverage { get; set; }
    //    public decimal NetIncomeperFullTimeEmployee { get; set; }
    //    public decimal IncPerEmployeeTotOps { get; set; }
    //    public decimal AccessionNumber { get; set; }
    //    public string FormType { get; set; }
    //}


    public class MessageInfo
    {
        public int MessageCode { get; set; }
        public string MessageDetail { get; set; }
    }

    public class GeneralInfo
    {
        public string ShareClassId { get; set; }
        public string CompanyName { get; set; }
        public string ExchangeId { get; set; }
        public string Symbol { get; set; }
        public string CUSIP { get; set; }
        public string CIK { get; set; }
        public string ISIN { get; set; }
        public string SEDOL { get; set; }
        public string CountryId { get; set; }
    }

    public class ProfitabilityEntityList
    {
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string CurrencyId { get; set; }
        public int FiscalYearEnd { get; set; }
        public double GrossMargin { get; set; }
        public double OperatingMargin { get; set; }
        public double EBTMargin { get; set; }
        public double TaxRate { get; set; }
        public double NetMargin { get; set; }
        public double SalesPerEmployee { get; set; }
        public double EBITMargin { get; set; }
        public double EBITDAMargin { get; set; }
        public double NormalizedNetProfitMargin { get; set; }
        public double InterestCoverage { get; set; }
        public double IncPerEmployeeTotOps { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public double NetIncomeperFullTimeEmployee { get; set; }
    }

    public class ProfitabilityRatios
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<ProfitabilityEntityList> ProfitabilityEntityList { get; set; }
    }
}
