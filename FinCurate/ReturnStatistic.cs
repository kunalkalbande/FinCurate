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
    
    public partial class ReturnStatistic
    {
        public string Symbol { get; set; }
        public string AsOfDate { get; set; }
        public Nullable<decimal> NumberOfMonths { get; set; }
        public Nullable<decimal> Mean { get; set; }
        public Nullable<decimal> StandardDeviation { get; set; }
        public Nullable<decimal> Best3MonthReturn { get; set; }
        public Nullable<decimal> Worst3MonthReturn { get; set; }
        public Nullable<decimal> Alpha { get; set; }
        public Nullable<decimal> Beta { get; set; }
        public Nullable<decimal> RSquare { get; set; }
        public int Id { get; set; }
    }
}