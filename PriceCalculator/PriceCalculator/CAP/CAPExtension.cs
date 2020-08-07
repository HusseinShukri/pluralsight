using PriceCalculator.PriceCalculator.Enums;
using PriceCalculator.PriceCalculator.Utilities;

namespace PriceCalculator.PriceCalculator.CAP
{
    public static class CAPExtension
    {
        public static double FindCAP(this ICAP value, double cost)
        {
            if (value.MoneyType == MoneyType.Persentage)
            {
                return MathUtilities.RoundInternalResult(MathUtilities.PercentageDivider(value.CAP * cost));
            }
            return value.CAP;
        }
    }
}