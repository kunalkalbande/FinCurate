using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class SharesSnapshotEntity
    {
        public string TSODate { get; set; }
        public double CompanyTSO { get; set; }
        public string ShareLevelTSOSource { get; set; }
        public string FloatDate { get; set; }
        public double FloatShare { get; set; }
        public double InsiderHolding { get; set; }
        public double FloatShareToTotalSharesOutstanding { get; set; }
        public string BalanceSheetDate { get; set; }
        public double ShareClassLevelTreasuryShareOutstanding { get; set; }
        public double SharesOutstandingWithBalanceSheetEndingDate { get; set; }
        public string Symbol { get; set; }
        public int ID { get; set; }
        public Nullable<decimal> ShareLevelTSO { get; set; }
        public Nullable<decimal> QuotedTSO { get; set; }
        public Nullable<decimal> UnquotedTSO { get; set; }


        //public Nullable<decimal> ShareClassLvlTreyShareOut { get; set; }
        //public Nullable<decimal> SharesOutBalSheetEndingDate { get; set; }




    }

    public class SharesSnapshotModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public SharesSnapshotEntity sharesSnapshotEntity { get; set; }
    }
}
