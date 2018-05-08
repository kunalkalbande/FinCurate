using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Models
{
    public class ValuationRatioEntity
    {
        public string AsOfDate { get; set; }
        public double SalesPerShare { get; set; }
        public double GrowthAnnSalesPerShare5Year { get; set; }
        public double BookValuePerShare { get; set; }
        public double CFPerShare { get; set; }
        public double FCFPerShare { get; set; }
        public double PriceToEPS { get; set; }
        public double RatioPE5YearHigh { get; set; }
        public double RatioPE5YearLow { get; set; }
        public double PriceToBook { get; set; }
        public double PriceToSales { get; set; }
        public double PriceToCashFlow { get; set; }
        public double PriceToFreeCashFlow { get; set; }
        public double DivRate { get; set; }
        public double DividendYield { get; set; }
        public double DivPayoutTotOps { get; set; }
        public double DivPayout5Year { get; set; }
        public double DivYield5Year { get; set; }
        public double PayoutRatio { get; set; }
        public double SustainableGrowthRate { get; set; }
        public double CashReturn { get; set; }
        public double ForwardEarningYield { get; set; }
        public double PEGRatio { get; set; }
        public double PEGPayback { get; set; }
        public double ForwardDividendYield { get; set; }
        public double ForwardPERatio { get; set; }
        public double TangibleBookValuePerShare { get; set; }
        public double TangibleBVPerShare3YrAvg { get; set; }
        public double TangibleBVPerShare5YrAvg { get; set; }
        public double EVToEBITDA { get; set; }
        public double RatioPE5YearAverage { get; set; }
        public double NormalizedPERatio { get; set; }
        public double FCFYield { get; set; }
        public double EVToForwardEBIT { get; set; }
        public double EVToForwardEBITDA { get; set; }
        public double EVToForwardRevenue { get; set; }
        public double TwoYearsEVToForwardEBIT { get; set; }
        public double TwoYearsEVToForwardEBITDA { get; set; }
        public double FirstYearEstimatedEPSGrowth { get; set; }
        public double SecondYearEstimatedEPSGrowth { get; set; }
        public double NormalizedPEG { get; set; }
        public int ID { get; set; }
        public string Symbol { get; set; }
    }

    public class ValuationRatios:APIBase
    {
        public MessageInfo MessageInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public List<ValuationRatioEntity> valuationRatioEntityList { get; set; }
    }

}
