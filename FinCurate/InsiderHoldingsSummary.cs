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
    
    public partial class InsiderHoldingsSummary
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> AsOfDate { get; set; }
        public Nullable<double> InsiderPercentOwned { get; set; }
        public Nullable<decimal> InsiderSharesOwned { get; set; }
        public Nullable<int> RecentTotalBuyerNumber { get; set; }
        public Nullable<int> RecentTotalSellerNumber { get; set; }
        public Nullable<int> RecentTotalSharesBought { get; set; }
        public Nullable<int> RecentTotalSharesSold { get; set; }
    }
}