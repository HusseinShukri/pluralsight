namespace PriceCalculator.PriceCalculator.Discount
{

    public interface IDiscount 
    {
        double GetDiscount();
        double GetDiscount(int code);
    }
}