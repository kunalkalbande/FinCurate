using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
 
    public class GrowthEntityList
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string ReportDate { get; set; }
        public string PeriodEndingDate { get; set; }
        public string FileDate { get; set; }
        public string StatementType { get; set; }
        public string DataType { get; set; }
        public int FiscalYearEnd { get; set; }
        public double DilutedEPS1YearGrowth { get; set; }
        public double DilutedEPS3YearGrowth { get; set; }
        public double DilutedEPS5YearGrowth { get; set; }
        public double DilutedEPS10YearGrowth { get; set; }
        public double DilutedContinuousEPS1YearGrowth { get; set; }
        public double DilutedContinuousEPS3YearGrowth { get; set; }
        public double DilutedContinuousEPS5YearGrowth { get; set; }
        public double DilutedContinuousEPS10YearGrowth { get; set; }
        public double Dividend1YearGrowth { get; set; }
        public double Dividend3YearGrowth { get; set; }
        public double Dividend5YearGrowth { get; set; }
        public double Dividend10YearGrowth { get; set; }
        public double EquityPerShare1YearGrowth { get; set; }
        public double EquityPerShare3YearGrowth { get; set; }
        public double EquityPerShare5YearGrowth { get; set; }
        public double EquityPerShare10YearGrowth { get; set; }
        public double Revenue1YearGrowth { get; set; }
        public double Revenue3YearGrowth { get; set; }
        public double Revenue5YearGrowth { get; set; }
        public double Revenue10YearGrowth { get; set; }
        public double OperatingIncome1YearGrowth { get; set; }
        public double OperatingIncome3YearGrowth { get; set; }
        public double OperatingIncome5YearGrowth { get; set; }
        public double OperatingIncome10YearGrowth { get; set; }
        public double NetIncome1YearGrowth { get; set; }
        public double NetIncome3YearGrowth { get; set; }
        public double NetIncome5YearGrowth { get; set; }
        public double NetIncome10YearGrowth { get; set; }
        public double NetIncomeContOps1YearGrowth { get; set; }
        public double NetIncomeContOps3YearGrowth { get; set; }
        public double NetIncomeContOps5YearGrowth { get; set; }
        public double NetIncomeContOps10YearGrowth { get; set; }
        public double CFO1YearGrowth { get; set; }
        public double CFO3YearGrowth { get; set; }
        public double CFO5YearGrowth { get; set; }
        public double CFO10YearGrowth { get; set; }
        public double FCF1YearGrowth { get; set; }
        public double FCF3YearGrowth { get; set; }
        public double FCF5YearGrowth { get; set; }
        public double FCF10YearGrowth { get; set; }
        public double OperatingRevenue1YearGrowth { get; set; }
        public double OperatingRevenue3YearGrowth { get; set; }
        public double OperatingRevenue5YearGrowth { get; set; }
        public double OperatingRevenue10YearGrowth { get; set; }
        public double GrowthAnnCapitalSpending5Year { get; set; }
        public double GrowthAnnGrossProfit5Year { get; set; }
        public double AvgGrossMargin5Year { get; set; }
        public double AvgPostTaxMargin5Year { get; set; }
        public double AvgPreTaxMargin5Year { get; set; }
        public double AvgNetProfitMargin5Year { get; set; }
        public double AvgRetCommonEquity5Year { get; set; }
        public double AvgRetAssets5Year { get; set; }
        public double AvgRetInvestedCapital5Year { get; set; }
        public string AccessionNumber { get; set; }
        public string FormType { get; set; }
        public double NormalizedDilutedEPSGrowth1year { get; set; }
        public double NormalizedDilutedEPSGrowth3year { get; set; }
        public double NormalizedDilutedEPSGrowth5year { get; set; }
        public double NormalizedDilutedEPSGrowth10year { get; set; }
        public string Interim { get; set; }
        public Nullable<decimal> DilutedEPS3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedEPS6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedEPS9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedEPSSequentialGrowth { get; set; }
        public Nullable<decimal> DilutedContinuousEPS3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedContinuousEPS6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedContinuousEPS9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DilutedContinuousEPSSequentialGrowth { get; set; }
        public Nullable<decimal> Dividend3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> Dividend6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> Dividend9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> DividendSequentialGrowth { get; set; }
        public Nullable<decimal> EquityPerShare3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> EquityPerShare6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> EquityPerShare9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> EquityPerShareSequentialGrowth { get; set; }
        public Nullable<decimal> Revenue3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> Revenue6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> Revenue9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> RevenueSequentialGrowth { get; set; }
        public Nullable<decimal> OperatingIncome3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingIncome6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingIncome9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingIncomeSequentialGrowth { get; set; }
        public Nullable<decimal> NetIncome3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncome6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncome9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncomeSequentialGrowth { get; set; }
        public Nullable<decimal> NetIncomeContOps3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncomeContOps6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncomeContOps9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> NetIncomeContOpsSequentialGrowth { get; set; }
        public Nullable<decimal> CFO3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> CFO6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> CFO9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> CFOSequentialGrowth { get; set; }
        public Nullable<decimal> FCF3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> FCF6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> FCF9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> FCFSequentialGrowth { get; set; }
        public Nullable<decimal> OperatingRevenue3MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingRevenue6MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingRevenue9MonthSamePeriodGrowth { get; set; }
        public Nullable<decimal> OperatingRevenueSequentialGrowth { get; set; }
        public Nullable<decimal> RegressionGrowthOperatingRevenue5Years { get; set; }
        public Nullable<decimal> NormalizedDilutedEPSSamePeriodGrowth3months { get; set; }
        public Nullable<decimal> NormalizedDilutedEPSSamePeriodGrowth6months { get; set; }
        public Nullable<decimal> NormalizedDilutedEPSSamePeriodGrowth9months { get; set; }
        public Nullable<decimal> NormalizedDilutedEPSSequentialGrowth { get; set; }
        public Nullable<decimal> NormalizedBasicEPSGrowth1year { get; set; }
        public Nullable<decimal> NormalizedBasicEPSGrowth3year { get; set; }
        public Nullable<decimal> NormalizedBasicEPSGrowth5year { get; set; }
        public Nullable<decimal> NormalizedBasicEPSGrowth10year { get; set; }
        public Nullable<decimal> NormalizedBasicEPSSamePeriodGrowth3months { get; set; }
        public Nullable<decimal> NormalizedBasicEPSSamePeriodGrowth6months { get; set; }
        public Nullable<decimal> NormalizedBasicEPSSamePeriodGrowth9months { get; set; }
        public Nullable<decimal> NormalizedBasicEPSSequentialGrowth { get; set; }
    }

    public class GrowthRatiosModel:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<GrowthEntityList> GrowthEntityList { get; set; }
    }
}
