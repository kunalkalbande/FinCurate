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
    
    public partial class ProfitabilityRatio
    {
        public string Symbol { get; set; }
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string CurrencyId { get; set; }
        public Nullable<int> FiscalYearEnd { get; set; }
        public Nullable<decimal> GrossMargin { get; set; }
        public Nullable<decimal> OperatingMargin { get; set; }
        public Nullable<decimal> EBTMargin { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<decimal> NetMargin { get; set; }
        public Nullable<decimal> SalesPerEmployee { get; set; }
        public Nullable<decimal> EBITMargin { get; set; }
        public Nullable<decimal> EBITDAMargin { get; set; }
        public Nullable<decimal> NormalizedNetProfitMargin { get; set; }
        public Nullable<decimal> InterestCoverage { get; set; }
        public Nullable<decimal> IncPerEmployeeTotOps { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public string NetIncomeperFullTimeEmployee { get; set; }
        public int Id { get; set; }
    }
}
