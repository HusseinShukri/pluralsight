using System;
namespace PriceCalculator.PriceCalculator.Utilities
{
    public class MathUtilities
    {
        public static double RoundInternalResult(double result)
        {
            return Math.Round(result, 4);
        }
        public static double RoundExternalResult(double result)
        {
            return Math.Round(result, 2);
        }
        public static double PercentageDivider(double persentage)
        {
            return RoundInternalResult(persentage / 100);
        }
        public static double FindTaxInternal(double taxPersentage, double cost)
        {
            return RoundInternalResult(PercentageDivider(taxPersentage) * cost);
        }
        public static double FindTaxExternal(double taxPersentage, double cost)
        {
            return RoundExternalResult(PercentageDivider(taxPersentage) * cost);
        }
    }
}