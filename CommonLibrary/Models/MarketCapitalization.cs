using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class MarketCapitalizationEntityList
    {
        public string MarketCapDate { get; set; }
        public double MarketCap { get; set; }
        public double EnterpriseValue { get; set; }
        public string CurrencyId { get; set; }
        public double SharesOutstanding { get; set; }
        public string SharesDate { get; set; }
        public string Symbol { get; set; }
        public int ID { get; set; }
    }

    public class MarketCapitalizationModel :APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<MarketCapitalizationEntityList> MarketCapitalizationEntityList { get; set; }
    }
}
