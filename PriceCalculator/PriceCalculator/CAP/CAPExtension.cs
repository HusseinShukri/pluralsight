using PriceCalculator.Common;
namespace PriceCalculator.CAP
{
    public static class CAPExtension
    {
        public static double FindCAP(this ICAP value, double cost)
        {
            if (value.getMoneyType() == MoneyType.Persentage)
            {
                return Tools.RoundInternalResult(Tools.PercentageDivider(value.getCAP()) * cost);
            }
            return value.getCAP();
        }
    }
}