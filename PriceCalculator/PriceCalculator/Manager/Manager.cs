using System.Linq;
using System;
using System.Collections.Generic;

namespace PriceCalculator.PriceCalculator.Manager
{
    public abstract class Manager : IManager
    {
        protected Manager() { }
        protected Manager(Enum type, IFather iFatherDerivedClass)
        {
            Dictionary.Add(type, iFatherDerivedClass);
        }
        protected Manager(Dictionary<Enum, IFather> dictionary)
        {
            this.Dictionary = dictionary;
        }
        public Dictionary<Enum, IFather> Dictionary { get; private set; }
        public bool AddItemByType(Enum type, IFather iFatherDerivedClass)
        {
            return Dictionary.TryAdd(type, iFatherDerivedClass);
        }
        public IFather GetItemByType(Enum type)
        {
            if (this.IsExist(type)) { return Dictionary[type]; }
            return null;
        }
        public bool IsEmpty()
        {
            return !Dictionary.Any();
        }
        public bool IsExist(Enum type)
        {
            return Dictionary.ContainsKey(type);
        }
        public bool RemoveItemByType(Enum type)
        {
            return Dictionary.Remove(type);
        }
        public bool UpdateOrAddItemByType(Enum type, IFather iFatherDerivedClass)
        {
            if (!this.AddItemByType(type, iFatherDerivedClass))
            {
                if (this.IsExist(type)) { Dictionary[type] = iFatherDerivedClass; }
                else { throw new Exception("bug in : Class Manager : Method UpdateOrAddItemByType ."); }
            }
            return true;
        }
    }
}