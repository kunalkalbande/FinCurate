using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CommonLibrary.Models
{
    //public class MessageInfo
    //{
    //    public int MessageCode { get; set; }
    //    public string MessageDetail { get; set; }
    //}

    //public class GeneralInfo
    //{
    //    public string ShareClassId { get; set; }
    //    public string CompanyName { get; set; }
    //    public string ExchangeId { get; set; }
    //    public string Symbol { get; set; }
    //    public string CUSIP { get; set; }
    //    public string CIK { get; set; }
    //    public string ISIN { get; set; }
    //    public string SEDOL { get; set; }
    //    public string CountryId { get; set; }
    //}

    public class ProfitabilityEntityList
    {
        public int Id { get; set; }
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
        public string Interim { get; set; }
        public double DaysInSales { get; set; }
        public double DaysInInventory { get; set; }
        public double DaysInPayment { get; set; }
        public double CashConversionCycle { get; set; }
        public double ReceivableTurnover { get; set; }
        public double InventoryTurnover { get; set; }
        public double PayableTurnover { get; set; }
        public double FixedAssetsTurnover { get; set; }
        public double AssetsTurnover { get; set; }
        public double ROE { get; set; }
        public double ROA { get; set; }
        public double ROIC { get; set; }
        public double FCFSalesRatio { get; set; }
        public double FCFNetIncomeRatio { get; set; }
        public double CapitalExpenditureSalesRatio { get; set; }
        public double ROE5YrAvg { get; set; }
        public double ROA5YrAvg { get; set; }
        public double AVG5YrsROIC { get; set; }
        public double NormalizedROIC { get; set; }
        public string Symbol { get; set; }
    }

    public class EfficiencyEntityList
    {
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string Interim { get; set; }
        public int FiscalYearEnd { get; set; }
        public double DaysInSales { get; set; }
        public double DaysInInventory { get; set; }
        public double DaysInPayment { get; set; }
        public double CashConversionCycle { get; set; }
        public double ReceivableTurnover { get; set; }
        public double InventoryTurnover { get; set; }
        public double PayableTurnover { get; set; }
        public double FixedAssetsTurnover { get; set; }
        public double AssetsTurnover { get; set; }
        public double ROE { get; set; }
        public double ROA { get; set; }
        public double ROIC { get; set; }
        public double FCFSalesRatio { get; set; }
        public double FCFNetIncomeRatio { get; set; }
        public double CapitalExpenditureSalesRatio { get; set; }
        public string AccessionNumber { get; set; }
        public double ROE5YrAvg { get; set; }
        public double ROA5YrAvg { get; set; }
        public double AVG5YrsROIC { get; set; }
        public string FormType { get; set; }
        public double NormalizedROIC { get; set; }
    }
    public class ProfitabilityRatios : APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<ProfitabilityEntityList> ProfitabilityEntityList { get; set; }
       

    }

    public class EfficiencyRatios : APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<EfficiencyEntityList> EfficiencyEntityList { get; set; }
    }
}
