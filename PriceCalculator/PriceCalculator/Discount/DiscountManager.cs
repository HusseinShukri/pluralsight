using System;
using System.Collections.Generic;
using PriceCalculator.Common;

namespace PriceCalculator.Discount
{
    public class DiscountManager
    {
        private Dictionary<DiscountType, IDiscount> discountDictionary = new Dictionary<DiscountType, IDiscount>();
        public DiscountManager() { }
        public DiscountManager(DiscountType type, IDiscount expenses)
        {
            this.discountDictionary.Add(type, expenses);
        }
        public DiscountManager(Dictionary<DiscountType, IDiscount> discountDictionary)
        {
            this.discountDictionary = discountDictionary;
        }

        public bool countainDiscountType(DiscountType type)
        {
            return discountDictionary.ContainsKey(type);
        }
        public IDiscount getDiscountByType(DiscountType type)
        {
            if (!this.countainDiscountType(type)) { return null; }
            else { return discountDictionary[type]; }
        }
        public bool AddDiscountType(DiscountType type, IDiscount expenses)
        {
            if (this.countainDiscountType(type))
            {
                return false;
            }
            return discountDictionary.TryAdd(type, expenses);

        }
        public bool updateOrAddEDiscountType(DiscountType type, IDiscount expenses)
        {
            if (!this.AddDiscountType(type, expenses))
            {
                if (this.countainDiscountType(type)) { discountDictionary[type] = expenses; }
                else { throw new Exception("bug in : Class ExpensesManager Method updateOrAddExpensesType Method"); }
            }
            return true;
        }
        public bool removeDiscountType(DiscountType type)
        {
            return discountDictionary.Remove(type);
        }
        public bool isEmpty()
        {
            return discountDictionary.Count == 0 ? true : false;
        }
    }
}