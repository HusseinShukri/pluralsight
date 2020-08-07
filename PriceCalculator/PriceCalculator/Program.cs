using System.Collections.Generic;
using PriceCalculator.PriceCalculator.CAP;
using PriceCalculator.PriceCalculator.Enums;
using PriceCalculator.PriceCalculator.Discount;
using PriceCalculator.PriceCalculator.Expenses;
using PriceCalculator.PriceCalculator.Products;
using PriceCalculator.PriceCalculator.Stores;
using PriceCalculator.PriceCalculator.Utilities;
namespace PriceCalculator.PriceCalculator
{
    class Program
    {
        private static CurrencyType currency = 0;
        private static string StringCurrency = currency.ToString();
        static void Main(string[] args)
        {
            //UI Methods
            Store AlErsal = new Store(CurrencyType.USD, 21, new DiscountManager(), new ExpensesManager(), new NullCAP());
            AlErsal.discountManager.AddDiscountType(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            AlErsal.discountManager.AddDiscountType(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));
            AlErsal.discountManager.AddDiscountType(DiscountType.UPCDiscountBeforeTaxApply, new UCPDiscount(12345, 7));
            AlErsal.expensesManager.AddExpensesType(ExpensesType.Transport, new ExpensesStander(MoneyType.Persentage, 3));
            AlErsal.CAP = new DiscountCAP(MoneyType.abslute, 10);
            Product book = new Products.Product("The Little Prince", 12345, 20.25);
            var list = new List<ExpensesType> { ExpensesType.Transport };
            System.Console.WriteLine(AlErsal.Report(book, false, list));

        }
    }
}
