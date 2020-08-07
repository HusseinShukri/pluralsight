using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.CAP
{
    public class NullCAP : ICAP
    {
        public NullCAP()
        {
        }

        public double CAP => 0;
        public MoneyType MoneyType => MoneyType.abslute;
        public override string ToString()
        {
            return "No CAP on discounts";
        }
    }
}