using System;
using PriceCalculator.PriceCalculator.Utilities;
using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.Expenses
{
    public static class ExpensesExtension
    {
        public static double FindExpenses(this IExpenses value, double cost)
        {
            if (value.MoneyType == MoneyType.Persentage)
            {
                return MathUtilities.RoundInternalResult(MathUtilities.PercentageDivider(value.Expense * cost));
            }
            return MathUtilities.RoundInternalResult(value.Expense);
        }
        public static double FindTotalExpenses(this ExpensesManager value, double cost)
        {
            var result = 0.0;
            IExpenses expenses;
            foreach (var type in Enum.GetValues(typeof(ExpensesType)))
            {
                expenses = value.GetExpensesByType((ExpensesType)(type));
                result += expenses.FindExpenses(cost);
            }
            return result;
        }
        public static double FindPackaging(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.GetExpensesByType(ExpensesType.Packaging), cost);
        }
        public static double FindTransport(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.GetExpensesByType(ExpensesType.Transport), cost);
        }
        public static double FindAdministrative(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.GetExpensesByType(ExpensesType.Administrative), cost);
        }
    }
}