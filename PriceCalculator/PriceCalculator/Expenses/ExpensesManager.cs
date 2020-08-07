using System.Linq;
using System;
using PriceCalculator.PriceCalculator.Enums;
using System.Collections.Generic;
using PriceCalculator.PriceCalculator.Utilities;
namespace PriceCalculator.PriceCalculator.Expenses
{
    public class ExpensesManager
    {
        private Dictionary<ExpensesType, IExpenses> _dictionary = new Dictionary<ExpensesType, IExpenses>();
        public ExpensesManager() { }
        public ExpensesManager(ExpensesType type, IExpenses expenses)
        {
            this._dictionary.Add(type, expenses);
        }
        public ExpensesManager(Dictionary<ExpensesType, IExpenses> dictionary)
        {
            this._dictionary = dictionary;
        }

        public IExpenses GetExpensesByType(ExpensesType type)
        {
            return _dictionary.GetValueOrDefault(type, new NullExpenses());
        }
        public Dictionary<ExpensesType, IExpenses> GetDictionary()
        {
            return _dictionary;
        }
        public bool AddExpensesType(ExpensesType type, IExpenses expenses)
        {
            return _dictionary.TryAdd(type, expenses);
        }
        public bool UpdateOrAddExpensesType(ExpensesType type, IExpenses expenses)
        {
            if (!this.AddExpensesType(type, expenses))
            {
                if (this.IsExist(type)) { _dictionary[type] = expenses; }
                else { throw new Exception("bug in : Class ExpensesManager Method updateOrAddExpensesType Method"); }
            }
            return true;
        }
        public bool RemoveExpensesType(ExpensesType type)
        {
            return _dictionary.Remove(type);
        }
        public bool IsExist(ExpensesType type)
        {
            return _dictionary.ContainsKey(type);
        }
        public bool IsEmpty()
        {
            return !_dictionary.Any();
        }
        public override string ToString()
        {
            string str = "";
            foreach (var item in _dictionary.Keys)
            {
                str += $"{CurrencyExtension.EnumToString(item)} : {_dictionary[item].MoneyType} : {_dictionary[item].Expense}@";
            }
            return str.Replace("@", System.Environment.NewLine);
        }
    }
}