using PriceCalculator.CAP;
using PriceCalculator.Common;
using PriceCalculator.Discount;
using PriceCalculator.Expenses;
using PriceCalculator.Product;
namespace PriceCalculator
{
    class Program
    {
        private static CurrencyType currency = 0;
        private static string StringCurrency = currency.ToString();
        static void Main(string[] args)
        {
            product book = new product("The Little Prince", 12345, 20.25);
            DiscountManager discountManager = new DiscountManager();
            discountManager.AddDiscountType(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            discountManager.AddDiscountType(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));

            ExpensesManager expensesManager = new ExpensesManager();
            expensesManager.AddExpensesType(ExpensesType.Transport, new ExpensesStander(MoneyType.Persentage, 3));

            DiscountCAP cap = new DiscountCAP(MoneyType.abslute, 10);
            var tax = 21;
            bool additive = true;
            System.Console.WriteLine(Report(book, tax));
            System.Console.WriteLine(Report(book, tax, discountManager, additive));
            System.Console.WriteLine(Report(book, tax, discountManager, expensesManager, additive));
        }

        #region toMoveAndSlice
        public static string Report(product product, double tax)
        {
            var cost = product.Price;
            var str = $"@Cost = {StringCurrency} {cost}@";
            tax = Tools.FindTaxExternal(tax, cost);
            str += $"Tax= {StringCurrency} {tax}@";
            str += $"Total Amount  = {StringCurrency} {Tools.RoundExternalResult(cost + tax)} No discount";
            str = "@@" + str + "@@";
            return str.Replace("@", System.Environment.NewLine);
        }
        public static string Report(product product, double tax, DiscountManager discountManager, bool additive)
        {
            var cost = product.Price;
            var str = $"Cost = {StringCurrency} {cost}@";
            var discount = discountManager.FindDiscountBeforeTaxAplay(product.UPCCode, cost);
            cost -= discount;
            tax = Tools.FindTaxExternal(tax, cost);
            if (additive)
            {
                discount += discountManager.FindDiscountafterTaxAplayAdditive(product.UPCCode, cost);
            }
            else
            {
                discount += discountManager.FindDiscountafterTaxAplayMultiplicative(product.UPCCode, cost);
            }
            str += $"Tax= {StringCurrency} {tax}@";
            str += $"Total Discount {StringCurrency} {discount}@";
            str += $"Total Amount = {StringCurrency} {Tools.RoundExternalResult((cost - discount) + tax)}";
            str = "@@" + str + "@@";
            return str.Replace("@", System.Environment.NewLine);
        }
        public static string Report(product product, double tax, DiscountManager discountManager, ExpensesManager expensesManager, bool additive)
        {
            var transport = 0.0;
            var packaging = 0.0;
            var Administrative = 0.0;
            var cost = product.Price;
            var str = $"Cost = {StringCurrency} {cost}@";
            var discount = discountManager.FindDiscountBeforeTaxAplay(product.UPCCode, cost);
            cost -= discount;
            tax = Tools.FindTaxExternal(tax, cost);
            if (additive)
            {
                discount += discountManager.FindDiscountafterTaxAplayAdditive(product.UPCCode, cost);
            }
            else
            {
                discount += discountManager.FindDiscountafterTaxAplayMultiplicative(product.UPCCode, cost);
            }
            if (!expensesManager.isEmpty())
            {
                transport = expensesManager.getExpensesByType(ExpensesType.Transport).getExpenses();
                packaging = expensesManager.getExpensesByType(ExpensesType.Packaging).getExpenses();
                Administrative = expensesManager.getExpensesByType(ExpensesType.Administrative).getExpenses();
                str += $"Transport = {transport}@";
                str += $"Administrative = {packaging}@";
                str += $"packaging = {Administrative} @";
            }
            str += $"Tax= {StringCurrency} {tax}@";
            str += $"Total Discount {StringCurrency} {discount}@";
            str += $"Total Amount = {StringCurrency} {Tools.RoundExternalResult((cost - discount) + (tax + transport + Administrative + packaging))}";
            str = "@@" + str + "@@";
            return str.Replace("@", System.Environment.NewLine);
        }
        public static string Report(product product, double tax, DiscountManager discountManager, ExpensesManager expensesManager, DiscountCAP cap, bool additive)
        {
            return "";
        }
        public static string Report(product product, double tax, ExpensesManager expensesManager)
        {
            return "";
        }
        public static string Report(product product, double tax, DiscountManager discountManager, DiscountCAP cap, bool additive)
        {
            return "";
        }
        #endregion
    }
}
