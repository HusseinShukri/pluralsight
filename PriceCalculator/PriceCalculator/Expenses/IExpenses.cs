using PriceCalculator.PriceCalculator.Enums;
namespace PriceCalculator.PriceCalculator.Expenses
{
    public interface IExpenses
    {
        double Expense { get; }
        MoneyType MoneyType { get; }
    }
}