using System;
using PriceCalculator.Common;
using System.Collections.Generic;
namespace PriceCalculator.Expenses
{
    public class ExpensesManager
    {
        private Dictionary<ExpensesType, IExpenses> expensesDictionary = new Dictionary<ExpensesType, IExpenses>();
        public ExpensesManager() { }
        public ExpensesManager(ExpensesType type, IExpenses expenses)
        {
            this.expensesDictionary.Add(type, expenses);
        }
        public ExpensesManager(Dictionary<ExpensesType, IExpenses> expensesDictionary)
        {
            this.expensesDictionary = expensesDictionary;
        }

        public bool countainExpensesType(ExpensesType type)
        {
            return expensesDictionary.ContainsKey(type);
        }
        public IExpenses getExpensesByType(ExpensesType type)
        {
            if (!this.countainExpensesType(type)) { return new NullExpenses(); }
            else { return expensesDictionary[type]; }
        }
        public Dictionary<ExpensesType, IExpenses> getExpensesDictionary()
        {
            return expensesDictionary;
        }
        public bool AddExpensesType(ExpensesType type, IExpenses expenses)
        {
            if (this.countainExpensesType(type))
            {
                return false;
            }
            return expensesDictionary.TryAdd(type, expenses);

        }
        public bool updateOrAddExpensesType(ExpensesType type, IExpenses expenses)
        {
            if (!this.AddExpensesType(type, expenses))
            {
                if (this.countainExpensesType(type)) { expensesDictionary[type] = expenses; }
                else { throw new Exception("bug in : Class ExpensesManager Method updateOrAddExpensesType Method"); }
            }
            return true;
        }
        public bool removeExpensesType(ExpensesType type)
        {
            return expensesDictionary.Remove(type);
        }
        public bool isEmpty()
        {
            return expensesDictionary.Count == 0 ? true : false;
        }
    }
}