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
    
    public partial class InstitutionalHoldingsSummaryHistory
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> AsOfDate { get; set; }
        public Nullable<int> NumberOfOwners { get; set; }
        public Nullable<decimal> TotalSharesOwned { get; set; }
        public Nullable<double> PercentageOwnership { get; set; }
        public Nullable<decimal> TotalSharesIncreased { get; set; }
        public Nullable<decimal> TotalSharesDecreased { get; set; }
    }
}
