using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class BalanceSheetEntityList
    {
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string Interim { get; set; }
        public string CurrencyId { get; set; }
        public int FiscalYearEnd { get; set; }
        public double AccountsPayable { get; set; }
        public double AccountsReceivable { get; set; }
        public double GrossAccountsReceivable { get; set; }
        public double NonCurrentAccountsReceivable { get; set; }
        public double AccumulatedDepreciation { get; set; }
        public double GainsLossesNotAffectingRetainedEarnings { get; set; }
        public double AllowanceForDoubtfulAccountsReceivable { get; set; }
        public double CapitalStock { get; set; }
        public double CashAndCashEquivalents { get; set; }
        public double CashCashEquivalentsAndShortTermInvestments { get; set; }
        public double CommonStock { get; set; }
        public double CommonStockEquity { get; set; }
        public double CurrentAssets { get; set; }
        public double CurrentDebt { get; set; }
        public double CurrentDebtAndCapitalLeaseObligation { get; set; }
        public double CurrentLiabilities { get; set; }
        public double NonCurrentDeferredLiabilities { get; set; }
        public double CurrentDeferredLiabilities { get; set; }
        public double CurrentDeferredRevenue { get; set; }
        public double NonCurrentDeferredRevenue { get; set; }
        public double NonCurrentDeferredTaxesAssets { get; set; }
        public double DefinedPensionBenefit { get; set; }
        public double EmployeeBenefits { get; set; }
        public double FinishedGoods { get; set; }
        public double Goodwill { get; set; }
        public double GoodwillAndOtherIntangibleAssets { get; set; }
        public double GrossPPE { get; set; }
        public double Inventory { get; set; }
        public double InvestmentsAndAdvances { get; set; }
        public double LongTermDebt { get; set; }
        public double LongTermDebtAndCapitalLeaseObligation { get; set; }
        public double MinorityInterest { get; set; }
        public double NetPPE { get; set; }
        public double OtherCurrentAssets { get; set; }
        public double OtherCurrentLiabilities { get; set; }
        public double OtherIntangibleAssets { get; set; }
        public double OtherReceivables { get; set; }
        public double ShortTermInvestments { get; set; }
        public double Payables { get; set; }
        public double PayablesAndAccruedExpenses { get; set; }
        public double NonCurrentPensionAndOtherPostretirementBenefitPlans { get; set; }
        public double PrepaidAssets { get; set; }
        public double Receivables { get; set; }
        public double RecievablesAdjustmentsAllowances { get; set; }
        public double RestrictedCash { get; set; }
        public double RetainedEarnings { get; set; }
        public double StockholdersEquity { get; set; }
        public double TotalTaxPayable { get; set; }
        public double TotalAssets { get; set; }
        public double TotalCapitalization { get; set; }
        public double TotalNonCurrentAssets { get; set; }
        public double TreasuryStock { get; set; }
        public double WorkInProcess { get; set; }
        public double OtherNonCurrentLiabilities { get; set; }
        public double InvestedCapital { get; set; }
        public double TangibleBookValue { get; set; }
        public double TotalEquity { get; set; }
        public double WorkingCapital { get; set; }
        public double TotalDebt { get; set; }
        public double CurrentDeferredAssets { get; set; }
        public double NonCurrentDeferredAssets { get; set; }
        public double OrdinarySharesNumber { get; set; }
        public double TreasurySharesNumber { get; set; }
        public double TotalLiabilitiesNetMinorityInterest { get; set; }
        public double TotalNonCurrentLiabilitiesNetMinorityInterest { get; set; }
        public double TotalEquityGrossMinorityInterest { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public double NetTangibleAssets { get; set; }
        public double PensionandOtherPostRetirementBenefitPlansCurrent { get; set; }
        public double OtherInvestments { get; set; }
        public string FiscalYearChange { get; set; }
    }

    public class BalanceSheetModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<BalanceSheetEntityList> BalanceSheetEntityList { get; set; }
    }
}
