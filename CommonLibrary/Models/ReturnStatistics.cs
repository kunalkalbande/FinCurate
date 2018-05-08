using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    //public class ReturnStatistics
    //{
        //public class MessageInfo
        //{
        //    public int MessageCode { get; set; }
        //    public string MessageDetail { get; set; }
        //}

        //public class GeneralInfo
        //{
        //    public string ShareClassId { get; set; }
        //    public string CompanyName { get; set; }
        //    public string ExchangeId { get; set; }
        //    public string Symbol { get; set; }
        //    public string CUSIP { get; set; }
        //    public string CIK { get; set; }
        //    public string ISIN { get; set; }
        //    public string SEDOL { get; set; }
        //    public string CountryId { get; set; }
        //}

        public class ReturnStatisticsEntityList
        {
            public string AsOfDate { get; set; }
            public double NumberOfMonths { get; set; }
            public double Mean { get; set; }
            public double StandardDeviation { get; set; }
            public double Best3MonthReturn { get; set; }
            public double Worst3MonthReturn { get; set; }
            public double? Alpha { get; set; }
            public double? Beta { get; set; }
            public double? RSquare { get; set; }
            public string Symbol { get; set; }
            public int Id { get; set; }
    }

        public class ReturnStatistics :APIBase
        {
            public MessageInfo MessageInfo { get; set; }
            public GeneralInfo GeneralInfo { get; set; }
            public List<ReturnStatisticsEntityList> ReturnStatisticsEntityList { get; set; }
        }
    //}
}
