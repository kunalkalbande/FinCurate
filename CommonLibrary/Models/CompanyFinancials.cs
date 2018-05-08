using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class CompanyFinancialAvailabilityEntityList
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string ExchangeId { get; set; }
        public string Symbol { get; set; }
        public string CUSIP { get; set; }
        public string CIK { get; set; }
        public string ISIN { get; set; }
        public string SEDOL { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string SectorId { get; set; }
        public string SectorName { get; set; }
        public string IndustryGroupId { get; set; }
        public string IndustryGroupName { get; set; }
        public string IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string LatestQuarterlyReportDate { get; set; }
        public string LatestAnnualReportDate { get; set; }
        public string LatestPreliminaryReportDate { get; set; }
        public string LatestSemiAnnualReportDate { get; set; }
        public string TemplateCode { get; set; }
    }

    public class CompanyFinancials:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public List<CompanyFinancialAvailabilityEntityList> CompanyFinancialAvailabilityEntityList { get; set; }
    }
}
