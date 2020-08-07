using System;
using System.Linq;
using System.Collections.Generic;
using PriceCalculator.PriceCalculator.Utilities;
using PriceCalculator.PriceCalculator.Enums;
using PriceCalculator.PriceCalculator.CAP;
using PriceCalculator.PriceCalculator.Discount;
using PriceCalculator.PriceCalculator.Expenses;
using PriceCalculator.PriceCalculator.Products;

namespace PriceCalculator.PriceCalculator.Stores
{
    public class Store
    {
        public CurrencyType storeMainCurrency;
        public DiscountManager discountManager;
        public ExpensesManager expensesManager;
        public ICAP CAP;
        public double Tax;

        public Store(CurrencyType storeMainCurrency, double tax, DiscountManager discountManager, ExpensesManager expensesManager, ICAP cAP)
        {
            this.storeMainCurrency = storeMainCurrency;
            this.discountManager = discountManager;
            this.expensesManager = expensesManager;
            CAP = cAP;
            Tax = tax;
        }
        #region StoreComponentsMethods
        public string AddExpenses(ExpensesType expensestype, MoneyType moneyType, double amount0rPersentage)
        {
            var isTrue = expensesManager.AddExpensesType(expensestype, new ExpensesStander(moneyType, amount0rPersentage));
            if (isTrue)
            {
                return "New expenses was successfully added";
            }
            return "This expenses is already exist";
        }
        public string UpdateOrAddExpenses(ExpensesType expensestype, MoneyType moneyType, double amount0rPersentage)
        {
            try
            {
                expensesManager.UpdateOrAddExpensesType(expensestype, new ExpensesStander(moneyType, amount0rPersentage));
                return "New expenses was successfully added";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string RemoveExpenses(ExpensesType expensestype)
        {
            var isTrue = expensesManager.RemoveExpensesType(expensestype);
            if (isTrue)
            {
                return $"{CurrencyExtension.EnumToString(expensestype)} was successfully removed";
            }
            return "This expenses is not existed";
        }
        public string AddUniversalDiscount(double amount)
        {
            var isTrue = discountManager.AddDiscountType(DiscountType.UniversalDiscount, new UniversalDiscount(amount));
            if (isTrue)
            {
                return "New expenses was successfully added";
            }
            return "This expenses is already exist";

        }
        public string AddUPCDiscount(DiscountType discountType, int code, double amount)
        {
            if (discountType == DiscountType.UniversalDiscount)
            {
                return $"Bad input {nameof(discountType)}";
            }
            var isTrue = discountManager.AddDiscountType(discountType, new UCPDiscount(code, amount));
            if (isTrue)
            {
                return "New discount was successfully added";
            }
            return "This discount is already exist";
        }
        public string UpdateOrAddUniversalDiscount(double amount)
        {
            try
            {
                discountManager.UpdateOrAddDiscountType(DiscountType.UniversalDiscount, new UniversalDiscount(amount));
                return "New discount was successfully added";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string UpdateOrAddUPCCode(DiscountType discountType, int code, double amount)
        {
            var isTrue = discountManager.UpdateOrAddUPCCodeDiscount(discountType, code, amount);
            if (isTrue)
            {
                return "New discount was successfully added";
            }
            else
            {
                discountManager.AddDiscountType(discountType, new UCPDiscount(code, amount));
                return "New discount was successfully added";
            }
        }
        public string RemoveDiscount(DiscountType discountType)
        {
            var isTrue = discountManager.RemoveDiscountType(discountType);
            if (isTrue)
            {
                return $"{CurrencyExtension.EnumToString(discountType)} was successfully removed";
            }
            return "This discount is not existed";
        }
        public string RemoveUPCDiscount(DiscountType discountType, int code)
        {
            var isTrue = discountManager.RemoveUPCCodeDiscount(discountType, code);
            if (isTrue)
            {
                return $"{code} for {CurrencyExtension.EnumToString(discountType)} was successfully removed";
            }
            return $"This {code} for {CurrencyExtension.EnumToString(discountType)} discount is not exist";
        }
        public string UpdateAddTax(double tax)
        {
            Tax = tax;
            return "New Tax {tax} updated successfully";
        }
        #endregion
        #region ReportsMethods
        public bool IsCAP(double cost, double discount)
        {
            if (!(CAP is NullCAP))
            {
                var cap = CAP.FindCAP(cost);
                if (cap < discount)
                {
                    return true;
                }
            }
            return false;
        }
        public string DiscountReport(double before, double after, bool additive)
        {
            var str = $"Before Tax discount = {this.storeMainCurrency} {before}@";
            str += $"After tax discount  = {this.storeMainCurrency} {after} ";
            str += additive ? "@Additively" : "@Multiplicatively";
            return str;
        }
        public double AfterTaxDiscount(int upc, double cost, bool additive)
        {
            if (additive)
            {
                return discountManager.FindDiscountafterTaxAplayAdditive(upc, cost);
            }
            else
            {
                return discountManager.FindDiscountafterTaxAplayMultiplicative(upc, cost);
            }
        }
        public string Report(Product product, bool additive, List<ExpensesType> expensesList)
        {
            var str = "";
            var cost = product.Price;
            str += $"@Cost = {this.storeMainCurrency} {cost}@";
            var beforeTaxDiscount = discountManager.FindDiscountBeforeTaxAplay(product.UPCCode, cost);
            var trueCAP = IsCAP(cost, beforeTaxDiscount);
            if (trueCAP)
            {
                beforeTaxDiscount = CAP.FindCAP(cost);
            }
            cost -= beforeTaxDiscount;
            var tax = MathUtilities.FindTaxExternal(this.Tax, cost);
            str += $"Tax= {this.storeMainCurrency} {tax}@";
            var afterTaxDiscount = 0.0;
            var totaldiscount = beforeTaxDiscount;
            if (!trueCAP)
            {
                afterTaxDiscount = AfterTaxDiscount(product.UPCCode, cost, additive);
                totaldiscount += afterTaxDiscount;
                trueCAP = IsCAP(cost, totaldiscount);
                if (trueCAP)
                {
                    totaldiscount = CAP.FindCAP(cost);
                    afterTaxDiscount = totaldiscount - beforeTaxDiscount;
                    cost -= afterTaxDiscount;
                }
                else
                {
                    cost -= afterTaxDiscount;
                }
            }
            str += $"Total Discount = {this.storeMainCurrency} {MathUtilities.RoundExternalResult(totaldiscount)}@";
            if (expensesList.Any())
            {
                var temp = 0.0;
                foreach (var item in expensesList)
                {
                    if (!expensesManager.IsExist(item))
                    {
                        return $"Please Enter {CurrencyExtension.EnumToString(item)} price first";
                    }
                    temp = expensesManager.GetExpensesByType(item).FindExpenses(cost);
                    str += $"{CurrencyExtension.EnumToString(item)} = {this.storeMainCurrency} {MathUtilities.RoundExternalResult(temp)}@";
                    cost += temp;
                }
            }
            str += $"Total Amount  = {this.storeMainCurrency} {MathUtilities.RoundExternalResult(cost + tax)}@@";
            if (totaldiscount != 0.0)
            {
                str += DiscountReport(beforeTaxDiscount, afterTaxDiscount, additive);
            }
            else
            {
                str += "NO Discount";
            }
            str = "@@" + str + "@@";
            return str.Replace("@", System.Environment.NewLine);
        }
        public string Statuse()
        {
            string str = "";
            str += $"Currency :@{CurrencyExtension.EnumToString(storeMainCurrency)}@";
            str += $"Discounts :@{discountManager.ToString()}";
            str += $"Discount CAP :@{CAP.MoneyType} : {CAP.CAP}@";
            str += $"Expenses :@{discountManager.ToString()}";
            return str.Replace("@", System.Environment.NewLine);
        }
        #endregion
    }
}