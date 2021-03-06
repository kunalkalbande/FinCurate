﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class IncomeStatementEntityList
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public string CurrencyId { get; set; }
        public string FiscalYearEnd { get; set; }
        public double Amortization { get; set; }
        public double CostOfRevenue { get; set; }
        public double DepreciationAndAmortization { get; set; }
        public double DepreciationAmortizationDepletion { get; set; }
        public double NetIncomeDiscontinuousOperations { get; set; }
        public double GainOnSaleOfSecurity { get; set; }
        public double GeneralAndAdministrativeExpense { get; set; }
        public double GrossProfit { get; set; }
        public double InterestExpense { get; set; }
        public double InterestExpenseNonOperating { get; set; }
        public double InterestIncomeNonOperating { get; set; }
        public double NetNonOperatingInterestIncomeExpense { get; set; }
        public double NetIncome { get; set; }
        public double NetIncomeCommonStockholders { get; set; }
        public double NetIncomeContinuousOperations { get; set; }
        public double NetInterestIncome { get; set; }
        public double TotalRevenue { get; set; }
        public double OperatingExpense { get; set; }
        public double OperatingIncome { get; set; }
        public double OperatingRevenue { get; set; }
        public double OtherIncomeExpense { get; set; }
        public double PretaxIncome { get; set; }
        public double ProvisionForDoubtfulAccounts { get; set; }
        public double TaxProvision { get; set; }
        public double ResearchAndDevelopment { get; set; }
        public double SalariesAndWages { get; set; }
        public double SellingAndMarketingExpense { get; set; }
        public double SellingGeneralAndAdministration { get; set; }
        public double TotalExpenses { get; set; }
        public double AmortizationOfIntangibles { get; set; }
        public double InterestIncome { get; set; }
        public double NetIncomeFromContinuingAndDiscontinuedOperation { get; set; }
        public double OtherOperatingExpenses { get; set; }
        public double ReconciledCostOfRevenue { get; set; }
        public double ReconciledDepreciation { get; set; }
        public double EarningBeforeInterestAndTax { get; set; }
        public double NormalizedIncome { get; set; }
        public double EBITDA { get; set; }
        public double BasicContinuousOperations { get; set; }
        public double BasicDiscontinuousOperations { get; set; }
        public double BasicEPS { get; set; }
        public double DilutedContinuousOperations { get; set; }
        public double DilutedDiscontinuousOperations { get; set; }
        public double DilutedEPS { get; set; }
        public double BasicAverageShares { get; set; }
        public double DilutedAverageShares { get; set; }
        public double DividendPerShare { get; set; }
        public double ContinuingAndDiscontinuedBasicEPS { get; set; }
        public double ContinuingAndDiscontinuedDilutedEPS { get; set; }
        public double NetIncomeFromContinuingOperationNetMinorityInterest { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public double NetIncomeIncludingNoncontrollingInterests { get; set; }
        public double OtherNonOperatingIncomeExpenses { get; set; }
        public double TotalUnusualItems { get; set; }
        public double TotalUnusualItemsExcludingGoodwill { get; set; }
        public double TaxRateForCalcs { get; set; }
        public double CalculatedTaxEffectOfUnusualItems { get; set; }
        public double NormalizedBasicEPS { get; set; }
        public double NormalizedDilutedEPS { get; set; }
        public string FiscalYearChange { get; set; }
        public double OtherGandA { get; set; }
        public double NormalizedPretaxIncome { get; set; }
        public double DividendCoverageRatio { get; set; }
    }

    public class IncomeStatementModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<IncomeStatementEntityList> IncomeStatementEntityList { get; set; }
    }
}
