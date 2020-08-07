using System.Linq;
using System;
using System.Collections.Generic;
using PriceCalculator.PriceCalculator.Utilities;
using PriceCalculator.PriceCalculator.Enums;

namespace PriceCalculator.PriceCalculator.Discount
{
    public class DiscountManager
    {
        private Dictionary<DiscountType, IDiscount> _dictionary = new Dictionary<DiscountType, IDiscount>();
        public DiscountManager() { }
        public DiscountManager(DiscountType type, IDiscount discount)
        {
            this._dictionary.Add(type, discount);
        }
        public DiscountManager(Dictionary<DiscountType, IDiscount> discountDictionary)
        {
            this._dictionary = discountDictionary;
        }

        public IDiscount GetDiscountByType(DiscountType type)
        {
            return _dictionary.GetValueOrDefault(type, new NullDiscount());
        }
        public Dictionary<DiscountType, IDiscount> GetDictionary()
        {
            return _dictionary;
        }
        public bool AddDiscountType(DiscountType type, IDiscount discount)
        {
            return _dictionary.TryAdd(type, discount);

        }
        public bool UpdateOrAddDiscountType(DiscountType type, IDiscount discount)
        {
            if (!this.AddDiscountType(type, discount))
            {
                if (this.IsExist(type)) { _dictionary[type] = discount; }
                else { throw new Exception("bug in : Class ExpensesManager Method updateOrAddExpensesType Method"); }
            }
            return true;
        }
        public bool AddUPCCodeDiscount(DiscountType type, int code, double price)
        {
            var uCPDiscount = _dictionary[type];
            if (uCPDiscount != null)
            {
                var t = (UCPDiscount)uCPDiscount;
                return t.AddDiscount(code, price);
            }
            return false;
        }
        public bool UpdateOrAddUPCCodeDiscount(DiscountType type, int code, double price)
        {
            var uCPDiscount = _dictionary[type];
            if (uCPDiscount != null)
            {
                var t = (UCPDiscount)uCPDiscount;
                return t.AddOrUpdateDiscount(code, price);
            }
            return false;
        }
        public bool RemoveDiscountType(DiscountType type)
        {
            return _dictionary.Remove(type);
        }
        public bool RemoveUPCCodeDiscount(DiscountType type, int code)
        {
            var uCPDiscount = _dictionary[type];
            if (uCPDiscount != null)
            {
                var t = (UCPDiscount)uCPDiscount;
                return t.RemoveDiscount(code);
            }
            return false;
        }
        public bool IsExist(DiscountType type)
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
                str += $"{CurrencyExtension.EnumToString(item)}@";
            }
            return str.Replace("@", System.Environment.NewLine);
        }
    }
}