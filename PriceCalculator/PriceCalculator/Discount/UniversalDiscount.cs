namespace PriceCalculator.Discount
{
    public class UniversalDiscount : IDiscount
    {
        private double discount;
        public UniversalDiscount(double discount)
        {
            this.discount = discount;
        }

        public double getDiscount()
        {
            return discount;
        }
        /// <returns>discount</returns>
        public double getDiscount(int code)
        {
            return discount;
        }
        public void newUniversalDiscount(double discount)
        {
            this.discount = discount;
        }
    }
}