using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class MiscellaneousInfoEntityList
    {
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string CurrencyId { get; set; }
        public int FiscalYearEnd { get; set; }
        public string AuditorName { get; set; }
        public string AuditorReportStatus { get; set; }
        public string InventoryValuationMethod { get; set; }
        public double NumberOfShareHolders { get; set; }
        public double TotalRiskBasedCapitalRatio { get; set; }
        public double NonAffiliatedValue { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public int ID { get; set; }
        public string Symbol { get; set; }
    }

    public class MiscellaneousInfoModel : APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<MiscellaneousInfoEntityList> MiscellaneousInfoEntityList { get; set; }
    }
}
