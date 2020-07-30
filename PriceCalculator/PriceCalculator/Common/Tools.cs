using System.Linq;
using System.Collections.Generic;
using System;
namespace PriceCalculator.Common
{
    public static class Tools
    {
        public static string CurrencyToString(CurrencyType type)
        {
            switch (type)
            {
                case CurrencyType.USD:
                    return "USD";
                case CurrencyType.GBP:
                    return "GBP";
                case CurrencyType.JPY:
                    return "JPY";
                default:
                    return "not add Currency";
            }
        }
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
            return Tools.RoundInternalResult(Tools.PercentageDivider(taxPersentage) * cost);
        }
        public static double FindTaxExternal(double taxPersentage, double cost)
        {
            return Tools.RoundExternalResult(Tools.PercentageDivider(taxPersentage) * cost);
        }














    }
}