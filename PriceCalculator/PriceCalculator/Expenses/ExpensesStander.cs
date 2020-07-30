using PriceCalculator.Common;
namespace PriceCalculator.Expenses
{
    public class ExpensesStander : IExpenses
    {
        private double expenses;
        private MoneyType moneyType;
        public ExpensesStander(MoneyType moneyType, double expenses)
        {
            this.expenses = expenses;
            this.moneyType = moneyType;
        }
        public double getExpenses()
        {
            return expenses;
        }
        public MoneyType getMoneyType()
        {
            return moneyType;
        }
        public void newExpenses(MoneyType moneyType, double expenses)
        {
            this.moneyType = moneyType;
            this.expenses = expenses;
        }
    }
}
