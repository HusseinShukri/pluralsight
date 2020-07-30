using System.Collections.Generic;
using System;
namespace PriceCalculator.Discount
{
    public class UCPDiscount : IDiscount
    {
        private Dictionary<int, double> dictionary;
        public UCPDiscount()
        {
            dictionary = new Dictionary<int, double>();
        }
        public UCPDiscount(int code, double persentage)
        {
            dictionary = new Dictionary<int, double>() { { code, persentage } };
        }
        public UCPDiscount(Dictionary<int, double> list)
        {
            dictionary = list;
        }

        public double getDiscount(int code)
        {
            return dictionary.GetValueOrDefault(code, 0);
        }
        /// <returns> 0 as not used method</returns>
        public double getDiscount()
        {
            return 0;
        }
        /// <returns>false if code existed true id new code</returns>
        public bool addDiscount(int code, double persentage)
        {
            return dictionary.TryAdd(code, persentage);
        }
        public bool addOrUpdateDiscount(int code, double persentage)
        {
            if (!addDiscount(code, persentage))
            {
                if (dictionary.ContainsKey(code)) { dictionary[code] = persentage; return true; }
                else { throw new Exception("bug in : Class UCPDiscount Method addOrUpdateDiscount Method"); }
            }
            return true;
        }
        public bool removeDiscount(int code)
        {
            return dictionary.Remove(code);
        }
    }
}