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
    
    public partial class EODPriceHistory
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> TradingDate { get; set; }
        public Nullable<decimal> PreviousClosePrice { get; set; }
        public Nullable<decimal> OpenPrice { get; set; }
        public Nullable<decimal> HighPrice { get; set; }
        public Nullable<decimal> LowPrice { get; set; }
        public Nullable<decimal> ClosePrice { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public string PriceCurrencyId { get; set; }
    }
}
