using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.CAP
{
    public class DiscountCAP : ICAP
    {
        public double CAP { get; private set; }
        public MoneyType MoneyType { get; private set; }

        public DiscountCAP(MoneyType moneyType, double cAP)
        {
            MoneyType = moneyType;
            CAP = cAP;
        }
    }
}