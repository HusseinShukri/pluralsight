using System.Collections.Generic;
using System;

namespace PriceCalculator.PriceCalculator.Manager
{
    public interface IManager
    {
        Dictionary<Enum, IFather> Dictionary { get; }
        IFather GetItemByType(Enum type);
        bool AddItemByType(Enum type, IFather iFatherDerivedClass);
        bool UpdateOrAddItemByType(Enum type, IFather iFatherDerivedClass);
        bool RemoveItemByType(Enum type);
        bool IsExist(Enum type);
        bool IsEmpty();
    }
}

