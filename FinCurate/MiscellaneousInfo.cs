//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinCurate
{
    using System;
    using System.Collections.Generic;
    
    public partial class MiscellaneousInfo
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<System.DateTime> PeriodEndingDate { get; set; }
        public Nullable<System.DateTime> FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string CurrencyId { get; set; }
        public Nullable<int> FiscalYearEnd { get; set; }
        public string AuditorName { get; set; }
        public string AuditorReportStatus { get; set; }
        public string InventoryValuationMethod { get; set; }
        public Nullable<int> NumberOfShareHolders { get; set; }
        public Nullable<double> TotalRiskBasedCapitalRatio { get; set; }
        public Nullable<decimal> NonAffiliatedValue { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
    }
}
