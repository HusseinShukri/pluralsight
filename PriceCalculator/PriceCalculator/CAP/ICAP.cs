using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.CAP
{
    public interface ICAP
    {
        double CAP { get; }
        MoneyType MoneyType { get; }
    }
}