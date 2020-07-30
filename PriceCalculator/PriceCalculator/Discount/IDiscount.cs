namespace PriceCalculator.Discount
{

    public interface IDiscount
    {
        double getDiscount();
        double getDiscount(int code);
    }
}