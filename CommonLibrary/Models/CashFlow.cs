using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class CashFlowEntityList
    {
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string Interim { get; set; }
        public string CurrencyId { get; set; }
        public int FiscalYearEnd { get; set; }
        public double Amortization { get; set; }
        public double CapitalExpenditure { get; set; }
        public double CashDividendsPaid { get; set; }
        public double CashFlowFromContinuingFinancingActivities { get; set; }
        public double CashFlowFromContinuingInvestingActivities { get; set; }
        public double CashFlowFromContinuingOperatingActivities { get; set; }
        public double FinancingCashFlow { get; set; }
        public double InvestingCashFlow { get; set; }
        public double OperatingCashFlow { get; set; }
        public double BeginningCashPosition { get; set; }
        public double EndCashPosition { get; set; }
        public double ChangesInCash { get; set; }
        public double ChangeInOtherWorkingCapital { get; set; }
        public double ChangeInWorkingCapital { get; set; }
        public double CommonStockDividendPaid { get; set; }
        public double Depreciation { get; set; }
        public double DepreciationAndAmortization { get; set; }
        public double DepreciationAmortizationDepletion { get; set; }
        public double EffectOfExchangeRateChanges { get; set; }
        public double NetCommonStockIssuance { get; set; }
        public double NetIssuancePaymentsOfDebt { get; set; }
        public double NetLongTermDebtIssuance { get; set; }
        public double NetShortTermDebtIssuance { get; set; }
        public double NetIncomeFromContinuingOperations { get; set; }
        public double OperatingGainsLosses { get; set; }
        public double NetOtherFinancingCharges { get; set; }
        public double NetOtherInvestingChanges { get; set; }
        public double OtherNonCashItems { get; set; }
        public double CommonStockPayments { get; set; }
        public double LongTermDebtPayments { get; set; }
        public double LongTermDebtIssuance { get; set; }
        public double PurchaseOfIntangibles { get; set; }
        public double PurchaseOfInvestment { get; set; }
        public double PurchaseOfPPE { get; set; }
        public double PurchaseOfBusiness { get; set; }
        public double NetBusinessPurchaseAndSale { get; set; }
        public double NetIntangiblesPurchaseAndSale { get; set; }
        public double NetInvestmentPurchaseAndSale { get; set; }
        public double NetPPEPurchaseAndSale { get; set; }
        public double SaleOfBusiness { get; set; }
        public double SaleOfInvestment { get; set; }
        public double SaleOfPPE { get; set; }
        public double StockBasedCompensation { get; set; }
        public double AmortizationOfIntangibles { get; set; }
        public double IssuanceOfDebt { get; set; }
        public double RepaymentOfDebt { get; set; }
        public double RepurchaseOfCapitalStock { get; set; }
        public double FreeCashFlow { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public string FiscalYearChange { get; set; }
        public string Symbol { get; set; }
        public int ID { get; set; }
    }

    public class CashFlowModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<CashFlowEntityList> CashFlowEntityList { get; set; }
    }
}
