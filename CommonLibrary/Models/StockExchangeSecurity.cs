using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class StockExchangeSecurityEntityList
    {
        public string CompanyName { get; set; }
        public string ExchangeId { get; set; }
        public string Symbol { get; set; }
        public string CUSIP { get; set; }
        public string CIK { get; set; }
        public string ISIN { get; set; }
        public string SEDOL { get; set; }
        public string InvestmentTypeId { get; set; }
        public string StockStatus { get; set; }
        public string ParValue { get; set; }
        public int Id { get; set; }
    }

    public class StockExchangeSecurityModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public List<StockExchangeSecurityEntityList> StockExchangeSecurityEntityList { get; set; }
    }
}
