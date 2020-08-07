namespace PriceCalculator.PriceCalculator.Discount
{
    public class UniversalDiscount : IDiscount
    {
        private double discount;
        public UniversalDiscount(double discount)
        {
            this.discount = discount;
        }
        public double GetDiscount()
        {
            return discount;
        }
        public double GetDiscount(int code)
        {
            return discount;
        }
    }
}