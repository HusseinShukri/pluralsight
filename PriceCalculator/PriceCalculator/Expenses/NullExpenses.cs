using PriceCalculator.Common;

namespace PriceCalculator.Expenses
{
    public class NullExpenses : IExpenses
    {
        public double getExpenses()
        {
            return 0;
        }

        public MoneyType getMoneyType()
        {
            return MoneyType.abslute;
        }
    }
}