using PriceCalculator.Common;
namespace PriceCalculator.CAP
{
    public interface ICAP
    {
        double getCAP();
        MoneyType getMoneyType();
    }
}