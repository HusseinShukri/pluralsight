using PriceCalculator.Common;
namespace PriceCalculator.Expenses
{
    public interface IExpenses
    {
        double getExpenses();
        MoneyType getMoneyType();
    }
}