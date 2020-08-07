using PriceCalculator.PriceCalculator.Discount;
using PriceCalculator.PriceCalculator.CAP;
using PriceCalculator.PriceCalculator.Enums;
using PriceCalculator.PriceCalculator.Expenses;
using PriceCalculator.PriceCalculator.Products;
using PriceCalculator.PriceCalculator.Utilities;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestPriceCalculator
{
    public class DiscountClasses
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var UPCObject = new UCPDiscount();
            //act
            var actual = UPCObject.AddDiscount(55, 30);
            actual = UPCObject.AddOrUpdateDiscount(55, 15);

            //assert
            Assert.True(actual);
        }
        [Fact]
        public void Test2()
        {
            //arrange
            var UPCObject = new UCPDiscount();
            //act
            var actual = UPCObject.AddDiscount(55, 30);
            actual = UPCObject.AddOrUpdateDiscount(55, 15);

            //assert
            Assert.Equal(15, UPCObject.GetDiscount(55));
        }
        [Fact]
        public void Test3()
        {

            var UPCObject = new UCPDiscount();
            var actual = UPCObject.GetDiscount();
            Assert.Equal(0, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            UniversalDiscount c = new UniversalDiscount(10);
            //act
            var actual = DiscountExtension.FindDiscount(c.GetDiscount(), 100);
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            UniversalDiscount c = new UniversalDiscount(7.6);
            //act
            var actual = DiscountExtension.FindDiscount(c.GetDiscount(), 56);
            //assert
            Assert.Equal(4.256, actual);
        }
        [Fact]
        public void Test6()
        {
            ///arrange
            var dictionary = new Dictionary<DiscountType, IDiscount>();
            dictionary.Add(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            dictionary.Add(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));
            var manager = new DiscountManager(dictionary);
            //act
            var actual = manager.FindDiscountBeforeTaxAplay(12345, 20.25);
            //assert
            Assert.Equal(0, actual);
        }
        [Fact]
        public void Test7()
        {
            ///arrange
            var dictionary = new Dictionary<DiscountType, IDiscount>();
            dictionary.Add(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            dictionary.Add(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));
            dictionary.Add(DiscountType.UPCDiscountBeforeTaxApply, new UCPDiscount(12345, 10));
            var manager = new DiscountManager(dictionary);
            //act
            var actual = manager.FindDiscountBeforeTaxAplay(12345, 90);
            //assert
            Assert.Equal(9, MathUtilities.RoundExternalResult(actual));
        }
        [Fact]
        public void Test8()

        {
            ///arrange
            var dictionary = new Dictionary<DiscountType, IDiscount>();
            dictionary.Add(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            dictionary.Add(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));
            var manager = new DiscountManager(dictionary);
            //act
            var actual = manager.FindDiscountafterTaxAplayAdditive(12345, 20.25);
            //assert
            Assert.Equal(4.46, actual);
        }
        [Fact]
        public void Test9()
        {
            ///arrange
            var dictionary = new Dictionary<DiscountType, IDiscount>();
            dictionary.Add(DiscountType.UniversalDiscount, new UniversalDiscount(15));
            dictionary.Add(DiscountType.UPCDiscountAfterTaxApply, new UCPDiscount(12345, 7));
            var manager = new DiscountManager(dictionary);
            //act
            var actual = manager.FindDiscountafterTaxAplayMultiplicative(12345, 20.25);
            //assert
            Assert.Equal(4.24, MathUtilities.RoundExternalResult(actual));
        }
    }
    public class CAPClassess
    {
        [Fact]
        public void Test1()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.Persentage, 50);
            //act
            var actual = CAPObject.CAP;
            //assert
            Assert.Equal(50, actual);

        }
        [Fact]
        public void Test2()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.Persentage, 50);
            //act
            var actual = CAPObject.MoneyType;
            //assert
            Assert.Equal(MoneyType.Persentage, actual);

        }
        [Fact]
        public void Test3()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.Persentage, 4);
            //act
            var actual = c.CAP;
            //assert
            Assert.Equal(4, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.Persentage, 4);
            //act
            var actual = c.MoneyType;
            //assert
            Assert.Equal(MoneyType.Persentage, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.abslute, 50);
            //act
            var actual = CAPObject.CAP;
            //assert
            Assert.Equal(50, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.abslute, 50);
            //act
            var actual = CAPObject.MoneyType;
            //assert
            Assert.Equal(MoneyType.abslute, actual);

        }
        [Fact]
        public void Test7()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.abslute, 4);
            //act
            var actual = c.CAP;
            //assert
            Assert.Equal(4, actual);
        }
        [Fact]
        public void Test8()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.abslute, 4);
            //act
            var actual = c.MoneyType;
            //assert
            Assert.Equal(MoneyType.abslute, actual);
        }
        [Fact]
        public void Test11()
        {
            //arrange
            DiscountCAP c = new DiscountCAP(MoneyType.abslute, 4);
            //act
            var actual = c.FindCAP(100);
            //assert
            Assert.Equal(4, c.CAP);
        }
        [Fact]
        public void Test12()
        {
            //arrange
            DiscountCAP c = new DiscountCAP(MoneyType.Persentage, 7.6);
            //act
            var actual = c.FindCAP(56);
            //assert
            Assert.Equal(4.256, actual);
        }
    }
    public class ExpensesClasses
    {
        [Fact]
        public void Test1()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.MoneyType;
            //assert
            Assert.Equal(MoneyType.abslute, actual);
        }
        [Fact]
        public void Test2()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.Expense;
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test3()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.Persentage, 10);
            //act
            var actual = transport.MoneyType;
            //assert
            Assert.Equal(MoneyType.Persentage, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.Expense;
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            IExpenses transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.MoneyType;
            //assert
            Assert.Equal(MoneyType.abslute, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            IExpenses transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.Expense;
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test7()
        {
            //arrange
            List<IExpenses> expensesList = new List<IExpenses>();
            IExpenses transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            expensesList.Add(new ExpensesStander(MoneyType.Persentage, 5));
            expensesList.Add(transport);
            var actual = expensesList[0].Expense;
            //assert
            Assert.Equal(5, actual);
        }
        [Fact]
        public void Test8()
        {
            /// constructor checker
            /// //arrange
            var manager = new ExpensesManager();
            //act
            var t1 = manager.IsExist(ExpensesType.Administrative);
            var t2 = manager.IsExist(ExpensesType.Transport);
            var t3 = manager.IsExist(ExpensesType.Packaging);
            var t4 = manager.IsEmpty();
            var t5 = manager.RemoveExpensesType(ExpensesType.Packaging);
            var t6 = manager.IsEmpty();
            //assert
            Assert.False(t1);
            Assert.False(t2);
            Assert.False(t3);
            Assert.True(t4);
            Assert.False(t5);
            Assert.True(t6);
        }
        [Fact]
        public void Test9()
        {
            //arrange
            var manager = new ExpensesManager(ExpensesType.Administrative, new ExpensesStander(MoneyType.abslute, 5));
            //act
            var t1 = manager.IsExist(ExpensesType.Administrative);
            var t2 = manager.IsExist(ExpensesType.Transport);
            var t3 = manager.IsExist(ExpensesType.Packaging);
            var t4 = manager.IsEmpty();
            var t5 = manager.RemoveExpensesType(ExpensesType.Packaging);
            var t6 = manager.IsEmpty();
            //assert
            Assert.True(t1);
            Assert.False(t2);
            Assert.False(t3);
            Assert.False(t4);
            Assert.False(t5);
            Assert.False(t6);
        }
        [Fact]
        public void Test10()
        {
            //arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.Persentage, 13));
            var manager = new ExpensesManager(dictionary);
            //act
            var t1 = manager.IsExist(ExpensesType.Administrative);
            var t2 = manager.IsExist(ExpensesType.Transport);
            var t3 = manager.IsExist(ExpensesType.Packaging);
            var t4 = manager.IsEmpty();
            var t5 = manager.RemoveExpensesType(ExpensesType.Packaging);
            var t6 = manager.IsEmpty();
            //assert
            Assert.False(t1);
            Assert.False(t2);
            Assert.True(t3);
            Assert.False(t4);
            Assert.True(t5);
            Assert.True(t6);
        }
        [Fact]
        public void Test11()
        {
            //arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.Persentage, 13));
            var manager = new ExpensesManager(dictionary);
            //act
            var t1 = manager.AddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 20));
            var t2 = manager.AddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 22));
            var t3 = manager.GetExpensesByType(ExpensesType.Administrative);
            //assert
            Assert.True(t1);
            Assert.False(t2);
            Assert.Equal(20, t3.Expense);
        }
        [Fact]
        public void Test12()
        {
            //arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.Persentage, 13));
            var manager = new ExpensesManager(dictionary);
            //act
            var t1 = manager.UpdateOrAddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 20));
            var t2 = manager.UpdateOrAddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 22));
            var t3 = manager.GetExpensesByType(ExpensesType.Administrative);
            //assert
            Assert.True(t1);
            Assert.True(t2);
            Assert.Equal(22, t3.Expense);
        }
        [Fact]
        public void Test13()
        {
            //arrange
            ExpensesStander c = new ExpensesStander(MoneyType.abslute, 4);
            //act
            var actual = c.FindExpenses(100);
            //assert
            Assert.Equal(4, c.Expense);
        }
        [Fact]
        public void Test14()
        {
            //arrange
            ExpensesStander c = new ExpensesStander(MoneyType.Persentage, 7.6);
            //act
            var actual = c.FindExpenses(56);
            //assert
            Assert.Equal(4.256, actual);
        }
        [Fact]
        public void Test15()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.abslute, 10));
            dictionary.Add(ExpensesType.Administrative, new ExpensesStander(MoneyType.abslute, 10));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindTotalExpenses(100);
            //assert
            // Assert.Equal(20, actual);
        }
        [Fact]
        public void Test16()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.abslute, 10));
            dictionary.Add(ExpensesType.Administrative, new ExpensesStander(MoneyType.abslute, 10));
            dictionary.Add(ExpensesType.Transport, new ExpensesStander(MoneyType.Persentage, 100));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindTotalExpenses(100);
            //assert
            Assert.Equal(120, actual);
        }
        [Fact]
        public void Test17()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.abslute, 10));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindPackaging(100);
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test18()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.Persentage, 7.6));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindPackaging(56);
            //assert
            Assert.Equal(4.256, actual);
        }
        [Fact]
        public void Test19()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Transport, new ExpensesStander(MoneyType.abslute, 10));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindTransport(100);
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test20()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Transport, new ExpensesStander(MoneyType.Persentage, 7.6));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindTransport(56);
            //assert
            Assert.Equal(4.256, actual);
        }
        [Fact]
        public void Test21()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Administrative, new ExpensesStander(MoneyType.abslute, 10));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindAdministrative(100);
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test22()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 7.6));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindAdministrative(56);
            //assert
            Assert.Equal(4.256, actual);
        }
        [Fact]
        public void Test23()
        {
            ///arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 7.6));
            var manager = new ExpensesManager(dictionary);
            //act
            var actual = manager.FindPackaging(56);
            //assert
            Assert.Equal(0, actual);
        }
    }
    public class productClass
    {
        [Fact]
        public void Test1()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.Name;
            //assert
            Assert.Equal("The Little Prince", actual);
        }
        [Fact]
        public void Test2()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            book.Name = "The Arabs";
            var actual = book.Name;
            //assert
            Assert.Equal("The Arabs", actual);
        }
        [Fact]
        public void Test3()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.Price;
            //assert
            Assert.Equal(20.25, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            book.Price = 18.0;
            var actual = book.Price;
            //assert
            Assert.Equal(18.0, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.UPCCode;
            //assert
            Assert.Equal(12345, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            book.UPCCode = 55;
            var actual = book.UPCCode;
            //assert
            Assert.Equal(55, actual);
        }
        [Fact]
        public void Test7()
        {
            //arrange
            Product book = new Product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.ToString();
            var expected = $"Name : {book.Name} UPC code :  {book.UPCCode }  price : {book.Price}";
            //assert
            Assert.Equal(expected, actual);

        }
    }
    public class CommonTools_CurrencyToString
    {
        [Fact]
        public void CurrencyToString_UDS()
        {
            //arrange
            var type = CurrencyType.USD;
            //act
            var str = CurrencyExtension.EnumToString(type);
            //assert
            Assert.Equal("USD", str);
        }
        [Fact]
        public void CurrencyToString_JPY()
        {
            //arrange
            var type = CurrencyType.JPY;
            //act
            var str = CurrencyExtension.EnumToString(type);
            //assert
            Assert.Equal("JPY", str);
        }
        [Fact]
        public void CurrencyToString_GBP()
        {
            //arrange
            var type = CurrencyType.GBP;
            //act
            var str = CurrencyExtension.EnumToString(type);
            //assert
            Assert.Equal("GBP", str);
        }
    }
    public class CommonTools_RoundResult
    {
        [Fact]
        public void RoundInternalResult()
        {
            //arrange
            var result = 12.34567;
            //act
            result = MathUtilities.RoundInternalResult(result);
            //assert
            Assert.Equal(12.3457, result);
        }
        [Fact]
        public void RoundExternalResult()
        {
            //arrange
            var result = 12.34567;
            //act
            result = MathUtilities.RoundExternalResult(result);
            //assert
            Assert.Equal(12.35, result);
        }
    }
    public class CommonTools_FindTax
    {
        [Fact]
        public void FindTaxByPersentage()
        {
            //arrange
            var cost = 20.25;
            var taxPersentage = 10;
            //act
            var tax = MathUtilities.FindTaxInternal(taxPersentage, cost);
            //assert
            Assert.Equal(2.025, tax);
        }
    }
    public class CommonTools_GetEnumValues
    {
        [Fact]
        public void testName()
        {
            // arrange
            Dictionary<string, int> d = new Dictionary<string, int>();
            //act
            int actual;
            var t = d.TryGetValue("i", out actual);
            //assert
            Assert.False(t);

        }
        [Fact]
        public void testName1()
        {
            // arrange
            Dictionary<string, int> d = new Dictionary<string, int>();
            //act
            d["i"] = 5;
            int actual;
            d.TryGetValue("i", out actual);
            //assert
            Assert.Equal(5, actual);

        }
        [Fact]
        public void testName2()
        {
            // arrange
            Dictionary<string, int> d = new Dictionary<string, int>();
            //act
            d["i"] = 5;
            d["i"] = 55;
            int actual;
            var t = d.TryGetValue("i", out actual);
            //assert
            Assert.Equal(55, actual);
            Assert.True(t);

        }
        [Fact]
        public void testName3()
        {
            // arrange
            Dictionary<string, int> d = new Dictionary<string, int>();
            //act
            d.TryAdd("i", 5);
            int actual;
            d.TryGetValue("i", out actual);
            //assert
            Assert.Equal(5, actual);

        }
        [Fact]
        public void testName4()
        {
            // arrange
            Dictionary<string, int> d = new Dictionary<string, int>();
            //act
            var t1 = d.TryAdd("i", 5);
            var t2 = d.TryAdd("i", 55);
            int actual;
            d.TryGetValue("i", out actual);
            //assert
            Assert.Equal(5, actual);
            Assert.True(t1);
            Assert.False(t2);

        }
    }
    public class classTypeChecker
    {
        [Fact]
        public void Test1()
        {
            // arrange
            List<ICAP> list = new List<ICAP>();
            //act
            list.Add(new NullCAP());
            //assert
            Assert.True(list[0] is NullCAP);
        }
        [Fact]
        public void Test2()
        {
            // arrange
            List<ICAP> list = new List<ICAP>();
            //act
            list.Add(new DiscountCAP(MoneyType.Persentage, 5));
            //assert
            Assert.False(list[0] is NullCAP);

        }
    }
}