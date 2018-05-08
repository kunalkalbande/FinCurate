using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class FinancialHealthEntityList
    {
        public int ID { get; set; }
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string Interim { get; set; }
        public int FiscalYearEnd { get; set; }
        public double CurrentRatio { get; set; }
        public double QuickRatio { get; set; }
        public double DebtTotalCapitalRatio { get; set; }
        public double DebtEquityRatio { get; set; }
        public double FinancialLeverage { get; set; }
        public double TotalDebtToEquity { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public double DebttoAssets { get; set; }
        public double CommonEquityToAssets { get; set; }
        public string Symbol { get; set; }
    }

    public class FinancialHealthRatioModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<FinancialHealthEntityList> FinancialHealthEntityList { get; set; }
    }
}
