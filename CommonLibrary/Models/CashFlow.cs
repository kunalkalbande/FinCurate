﻿using System;
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
        public int Id { get; set; }
        public string ChangeInAccountPayable { get; set; }
        public string ChangeInInventory { get; set; }
        public string ChangeInPayable { get; set; }
        public string ChangeInPayablesAndAccruedExpense { get; set; }
        public string ChangeInReceivables { get; set; }
        public string DeferredIncomeTax { get; set; }
        public string DeferredTax { get; set; }
        public string GainLossOnSaleOfBusiness { get; set; }
        public string IncomeTaxPaidSupplementalData { get; set; }
        public string InterestPaidSupplementalData { get; set; }
        public string AmortizationOfFinancingCostsAndDiscounts { get; set; }
        public string AmortizationOfSecurities { get; set; }
        public string AssetImpairmentCharge { get; set; }
        public string CallsMaturitiesOfMaturitySecurities { get; set; }
        public string NetCapitalExpenditureDisposals { get; set; }
        public string CapitalExpenditureReported { get; set; }
        public string CashFlowFromDiscontinuedOperation { get; set; }
        public string CashFromDiscontinuedFinancingActivities { get; set; }
        public string CashFromDiscontinuedInvestingActivities { get; set; }
        public string ChangeInDividendPayable { get; set; }
        public string ChangeInTaxPayable { get; set; }
        public string ChangeInAccruedExpense { get; set; }
        public string ChangeInAccruedInvestmentIncome { get; set; }
        public string ChangeInDeferredAcquisitionCosts { get; set; }
        public string ChangeInDeferredCharges { get; set; }
        public string ChangeInFederalFundsAndSecuritiesSoldForRepurchase { get; set; }
        public string ChangeInFundsWithheld { get; set; }
        public string ChangeInIncomeTaxPayable { get; set; }
        public string ChangeInInterestPayable { get; set; }
        public string ChangeInLoans { get; set; }
        public string ChangeInLossAndLossAdjustmentExpenseReserves { get; set; }
        public string ChangeInOtherCurrentAssets { get; set; }
        public string ChangeInOtherCurrentLiabilities { get; set; }
        public string ChangeInPremiumsReceivable { get; set; }
        public string ChangeInPrepaidAssets { get; set; }
        public string ChangeInPrepaidReinsurancePremiums { get; set; }
        public string ChangeInReinsuranceReceivableOnPaidLosses { get; set; }
        public string ChangeInReinsuranceRecoverableOnPaidAndUnpaidLosses { get; set; }
        public string ChangeInReinsuranceRecoverableOnUnpaidLosses { get; set; }
        public string ChangeInRestrictedCash { get; set; }
        public string ChangeInTradingAccountSecurities { get; set; }
        public string ChangeInUnearnedPremiums { get; set; }
        public string ChangeInUnearnedPremiumsCeded { get; set; }
        public string CumulativeEffectOfAccountingChange { get; set; }
        public string Depletion { get; set; }
        public string EarningsLossesFromEquityInvestments { get; set; }
        public string ExcessTaxBenefitFromStockBasedCompensation { get; set; }
        public string ExtraordinaryItems { get; set; }
        public string GainLossOnInvestmentSecurities { get; set; }
        public string GainLossOnSaleOfPPE { get; set; }
        public string IncreaseDecreaseInDeposit { get; set; }
        public string InterestCreditedOnPolicyholderDeposits { get; set; }
        public string NetPreferredStockIssuance { get; set; }
        public string CashFromDiscontinuedOperatingActivities { get; set; }
        public string NetForeignCurrencyExchangeGainLoss { get; set; }
        public string NetIncome { get; set; }
        public string NetIncomeFromDiscontinuedOperations { get; set; }
        public string NetRealizedInvestmentGains { get; set; }
        public string PaymentForLoans { get; set; }
        public string PreferredStockPayments { get; set; }
        public string ShortTermDebtPayments { get; set; }
        public string PensionAndEmployeeBenefitExpense { get; set; }
        public string PreferredStockDividendPaid { get; set; }
        public string ProceedsFromIssuanceOfWarrants { get; set; }
        public string ProceedsFromLoans { get; set; }
        public string ProceedsFromStockOptionExercised { get; set; }
        public string CommonStockIssuance { get; set; }
        public string PreferredStockIssuance { get; set; }
        public string ShortTermDebtIssuance { get; set; }
        public string ProceedsPaymentFederalFundsSoldAndSecuritiesPurchasedUnderAgreementToResell { get; set; }
        public string NetProceedsPaymentForLoan { get; set; }
        public string ProceedsPaymentInInterestBearingDepositsInBank { get; set; }
        public string ProvisionForLoanLeaseAndOtherLosses { get; set; }
        public string PurchaseOfEquitySecurities { get; set; }
        public string PurchaseOfFixedMaturitySecurities { get; set; }
        public string PurchaseOfLongTermInvestments { get; set; }
        public string PurchaseOfShortTermInvestments { get; set; }
        public string PurchaseOfTechnology { get; set; }
        public string NetTechnologyPurchaseAndSale { get; set; }
        public string RealizedGainLossOnSaleOfLoansAndLease { get; set; }
        public string SaleOfIntangibles { get; set; }
        public string SaleOfLongTermInvestments { get; set; }
        public string SaleOfShortTermInvestments { get; set; }
        public string SaleOfTechnology { get; set; }
        public string SalesOfEquitySecurities { get; set; }
        public string SalesOfFixedMaturitySecurities { get; set; }
        public string UnrealizedGainLossOnInvestmentSecurities { get; set; }
        public string UnrealizedGainsLossesOnDerivatives { get; set; }
        public string AllowanceForFundsConstruction { get; set; }
        public string ChangesInAccountReceivables { get; set; }
        public string DomesticSales { get; set; }
        public string ForeignSales { get; set; }
        public string IssuanceOfCapitalStock { get; set; }
        public string DirectCashFlowsFromOperatingActivities { get; set; }
        public string DecreaseinInterestBearingDepositsinBank { get; set; }
        public string IncreaseinInterestBearingDepositsinBank { get; set; }
        public string AdjustedGeographySegmentData { get; set; }
        public string InterestReceivedCFO { get; set; }
        public string InterestPaidCFO { get; set; }
        public string PurchaseofSubsidiaries { get; set; }
        public string PurchaseofJointVentureAssociate { get; set; }
        public string SaleofSubsidiaries { get; set; }
        public string SaleofJointVentureAssociate { get; set; }
        public string IncreaseDecreaseinLeaseFinancing { get; set; }
        public string IncreaseinLeaseFinancing { get; set; }
        public string RepaymentinLeaseFinancing { get; set; }
        public string ShareofAssociates { get; set; }
        public string ProfitonDisposals { get; set; }
        public string ReorganizationOtherCosts { get; set; }
        public string OtherFinancing { get; set; }
        public string NetOutwardLoans { get; set; }
        public string IssueExpenses { get; set; }
        public string ChangeinCertificatesofDepositsandDebtSecuritiesIssued { get; set; }
        public string PaymentstoAcquireHeldToMaturityInvestments { get; set; }
        public string PaymentstoAcquireAvailableForSaleFinancialAssets { get; set; }
        public string PaymentstoAcquireFinancialAssetsDesignatedasFairValue { get; set; }
        public string ProceedsfromDisposalofHeldToMaturityInvestments { get; set; }
        public string ProceedsfromDisposalofAvailableForSaleFinancialAssets { get; set; }
        public string ProceedsfromDisposalofFinancialAssetsDesignatedasFairValue { get; set; }
        public string ChangeinFairValueofInvestmentProperties { get; set; }
        public string ChangeinDepositsbyBanksandCustomers { get; set; }
        public string CashFlowsfromusedinOperatingActivitiesDirect { get; set; }
        public string ClassesofCashReceiptsfromOperatingActivities { get; set; }
        public string OtherCashReceiptsfromOperatingActivities { get; set; }
        public string ClassesofCashPayments { get; set; }
        public string PaymentstoSuppliersforGoodsandServices { get; set; }
        public string PaymentsfromContractsHeldforDealingorTradingPurpose { get; set; }
        public string PaymentsonBehalfofEmployees { get; set; }
        public string PaymentsforPremiumsandClaimsAnnuitiesandOtherPolicyBenefits { get; set; }
        public string OtherCashPaymentsfromOperatingActivities { get; set; }
        public string DividendsPaidDirect { get; set; }
        public string DividendsReceivedDirect { get; set; }
        public string InterestPaidDirect { get; set; }
        public string InterestReceivedDirect { get; set; }
        public string TaxesRefundPaidDirect { get; set; }
        public string TotalAdjustmentsforNonCashItems { get; set; }
        public string ImpairmentLossReversalRecognizedinProfitorLoss { get; set; }
        public string AdjustmentsforUndistributedProfitsofAssociates { get; set; }
        public string OtherAdjustmentsforWhichCashEffectsAreInvestingorFinancingCashFlow { get; set; }
        public string DividendPaidCFO { get; set; }
        public string DividendReceivedCFO { get; set; }
        public string TaxesRefundPaid { get; set; }
        public string OtherOperatingInflowsOutflowsofCash { get; set; }
        public string ProceedsfromGovernmentGrantsCFI { get; set; }
        public string CashAdvancesandLoansMadetoOtherParties { get; set; }
        public string CashReceiptsfromRepaymentofAdvancesandLoansMadetoOtherParties { get; set; }
        public string CashReceiptsfromPaymentsforFinancialDerivativeContracts { get; set; }
        public string DividendsReceivedCFI { get; set; }
        public string InterestReceivedCFI { get; set; }
        public string IncomeTaxesRefundPaidCFI { get; set; }
        public string IssuancePaymentofOtherEquityInstrumentsNet { get; set; }
        public string PaymentsofOtherEquityInstruments { get; set; }
        public string ProceedsfromIssuingOtherEquityInstruments { get; set; }
        public string ProceedsfromGovernmentGrantsCFF { get; set; }
        public string InterestPaidCFF { get; set; }
        public string IncomeTaxesRefundPaidCFF { get; set; }
        public string ChangeinAccruedIncome { get; set; }
        public string ChangeinDeferredIncome { get; set; }
        public string ChangeinFinancialAssets { get; set; }
        public string ChangeinAdvancesfromCentralBanks { get; set; }
        public string ChangeinFinancialLiabilities { get; set; }
        public string ChangeinInsuranceContractAssets { get; set; }
        public string ChangeinReinsuranceReceivables { get; set; }
        public string ChangeinDeferredAcquisitionCostsNet { get; set; }
        public string ChangeinInsuranceFunds { get; set; }
        public string ChangeinReinsurancePayables { get; set; }
        public string ChangeinInvestmentContractLiabilities { get; set; }
        public string ChangeinInsuranceContractLiabilities { get; set; }
        public string ProvisionandWriteOffofAssets { get; set; }
        public string ReceiptsfromCustomers { get; set; }
        public string ReceiptsfromGovernmentGrants { get; set; }
        public string MinorityInterest { get; set; }
        public string CashDividendsForMinorities { get; set; }
        public string FundFromOperation { get; set; }
        public string NetInvestmentPropertiesPurchaseAndSale { get; set; }
        public string PurchaseOfInvestmentProperties { get; set; }
        public string SaleOfInvestmentProperties { get; set; }
        public string OtherCashAdjustIncludedIntoChangeinCash { get; set; }
        public string OtherCashAdjustExcludeFromChangeinCash { get; set; }
      
    }

    public class CashFlowModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<CashFlowEntityList> CashFlowEntityList { get; set; }
    }
}
