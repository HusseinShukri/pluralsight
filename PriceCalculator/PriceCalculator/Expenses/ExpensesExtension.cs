using System;
using PriceCalculator.Common;
namespace PriceCalculator.Expenses
{
    public static class ExpensesExtension
    {
        public static double FindExpenses(this IExpenses value, double cost)
        {
            if (value.getMoneyType() == MoneyType.Persentage)
            {
                return Tools.RoundInternalResult(Tools.PercentageDivider(value.getExpenses()) * cost);
            }
            return Tools.RoundInternalResult(value.getExpenses());
        }
        public static double FindTotalExpenses(this ExpensesManager value, double cost)
        {
            var result = 0.0;
            IExpenses expenses;
            foreach (var type in Enum.GetValues(typeof(ExpensesType)))
            {
                expenses = value.getExpensesByType((ExpensesType)(type));
                result += expenses.FindExpenses(cost);
            }
            return result;
        }
        public static double findPackaging(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.getExpensesByType(ExpensesType.Packaging), cost);
        }
        public static double findTransport(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.getExpensesByType(ExpensesType.Transport), cost);
        }
        public static double findAdministrative(this ExpensesManager value, double cost)
        {
            return FindExpenses(value.getExpensesByType(ExpensesType.Administrative), cost);
        }

    }
}