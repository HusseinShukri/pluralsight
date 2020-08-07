using PriceCalculator.PriceCalculator.Enums;
namespace PriceCalculator.PriceCalculator.Expenses
{
    public class ExpensesStander : IExpenses
    {
        public double Expense { get; private set; }
        public MoneyType MoneyType { get; private set; }
        public ExpensesStander(MoneyType moneyType, double expenses)
        {
            MoneyType = moneyType;
            Expense = expenses;
        }
    }
}
