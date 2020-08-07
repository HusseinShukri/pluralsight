namespace PriceCalculator.PriceCalculator.Discount
{
    public class NullDiscount : IDiscount
    {
        public double GetDiscount() => 0;

        public double GetDiscount(int code) => 0;
    }
}