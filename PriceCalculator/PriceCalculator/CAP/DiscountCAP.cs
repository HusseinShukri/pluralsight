using PriceCalculator.Common;
namespace PriceCalculator.CAP
{
    public class DiscountCAP : ICAP
    {
        private double cap;
        private MoneyType type;
        public DiscountCAP(MoneyType type, double cap)
        {
            this.type = type;
            this.cap = cap;
        }
        public double getCAP()
        {
            return cap;
        }
        public MoneyType getMoneyType()
        {
            return type;
        }
        public void newCAP(MoneyType type, double cap)
        {
            this.type = type;
            this.cap = cap;
        }
    }
}