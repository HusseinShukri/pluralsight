using System;
using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.Expenses
{
    public class NullExpenses : IExpenses
    {
        public NullExpenses()
        {
        }

        public double Expense => 0;
        public MoneyType MoneyType => MoneyType.NullType;
        public override String ToString()
        {
            return "No expenses";
        }

    }
}