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
    
    public partial class PreferredStockYield
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> AsOfDate { get; set; }
        public Nullable<decimal> CurrentYield { get; set; }
        public string YieldTosFirstRedemptionDate { get; set; }
        public Nullable<decimal> YieldToMaturity { get; set; }
        public Nullable<decimal> StripYield { get; set; }
        public Nullable<decimal> YieldToWorst { get; set; }
    }
}
