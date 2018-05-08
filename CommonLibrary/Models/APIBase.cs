using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class APIBase
    {

        public class MessageInfo
        {
            public int MessageCode { get; set; }
            public string MessageDetail { get; set; }
        }

        public class GeneralInfo
        {
            public string ShareClassId { get; set; }
            public string CompanyName { get; set; }
            public string ExchangeId { get; set; }
            public string Symbol { get; set; }
            public string CUSIP { get; set; }
            public string CIK { get; set; }
            public string ISIN { get; set; }
            public string SEDOL { get; set; }
            public string CountryId { get; set; }
        }
    }
}
