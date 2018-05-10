using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class SharesHistoryEntityList
    {
        public string TSODate { get; set; }
        public double CompanyTSO { get; set; }
        public string ShareLevelTSOSource { get; set; }
        public string BalanceSheetDate { get; set; }
        public double ShareClassLevelTreasuryShareOutstanding { get; set; }
        public double SharesOutstandingWithBalanceSheetEndingDate { get; set; }
        public double? ShareLevelTSO { get; set; }
        public string FloatDate { get; set; }
        public double? FloatShare { get; set; }
        public double? InsiderHolding { get; set; }
        public double? FloatShareToTotalSharesOutstanding { get; set; }
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string QuotedTSO { get; set; }
        public string UnquotedTSO { get; set; }
        public string ReasonOfShareChange { get; set; }
        public string ShareClassLevelTreasuryShareOutstandingFromCover { get; set; }
        public string ShareClassLevelTreasuryShareOutstandingFromInterim { get; set; }
        public string ShareClassLevelTreasuryShareOutstandingFromOther { get; set; }



    }

    public class SharesHistoryModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<SharesHistoryEntityList> SharesHistoryEntityList { get; set; }
    }
}
