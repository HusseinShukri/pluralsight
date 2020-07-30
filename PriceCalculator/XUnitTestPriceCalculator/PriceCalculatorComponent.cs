using PriceCalculator.Discount;
using PriceCalculator.CAP;
using PriceCalculator.Common;
using PriceCalculator.Expenses;
using PriceCalculator.Product;
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
            var actual = UPCObject.addDiscount(55, 30);
            actual = UPCObject.addOrUpdateDiscount(55, 15);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void Test2()
        {
            //arrange
            var UPCObject = new UCPDiscount();
            //act
            var actual = UPCObject.addDiscount(55, 30);
            actual = UPCObject.addOrUpdateDiscount(55, 15);

            //assert
            Assert.Equal(15, UPCObject.getDiscount(55));
        }

        [Fact]
        public void Test3()
        {

            var UPCObject = new UCPDiscount();
            var actual = UPCObject.getDiscount();
            Assert.Equal(0, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            UniversalDiscount c = new UniversalDiscount(10);
            //act
            var actual = DiscountExtension.FindDiscount(c.getDiscount(), 100);
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            UniversalDiscount c = new UniversalDiscount(7.6);
            //act
            var actual = DiscountExtension.FindDiscount(c.getDiscount(), 56);
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
            Assert.Equal(9, Tools.RoundExternalResult(actual));
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
            Assert.Equal(4.24, Tools.RoundExternalResult(actual));
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
            var actual = CAPObject.getCAP();
            //assert
            Assert.Equal(50, actual);

        }
        [Fact]
        public void Test2()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.Persentage, 50);
            //act
            var actual = CAPObject.getMoneyType();
            //assert
            Assert.Equal(MoneyType.Persentage, actual);

        }
        [Fact]
        public void Test3()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.Persentage, 4);
            //act
            var actual = c.getCAP();
            //assert
            Assert.Equal(4, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.Persentage, 4);
            //act
            var actual = c.getMoneyType();
            //assert
            Assert.Equal(MoneyType.Persentage, actual);
        }

        [Fact]
        public void Test5()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.abslute, 50);
            //act
            var actual = CAPObject.getCAP();
            //assert
            Assert.Equal(50, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            DiscountCAP CAPObject = new DiscountCAP(MoneyType.abslute, 50);
            //act
            var actual = CAPObject.getMoneyType();
            //assert
            Assert.Equal(MoneyType.abslute, actual);

        }

        [Fact]
        public void Test7()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.abslute, 4);
            //act
            var actual = c.getCAP();
            //assert
            Assert.Equal(4, actual);
        }
        [Fact]
        public void Test8()
        {
            //arrange
            ICAP c = new DiscountCAP(MoneyType.abslute, 4);
            //act
            var actual = c.getMoneyType();
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
            Assert.Equal(4, c.getCAP());
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
            var actual = transport.getMoneyType();
            //assert
            Assert.Equal(MoneyType.abslute, actual);
        }
        [Fact]
        public void Test2()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.getExpenses();
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test3()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.Persentage, 10);
            //act
            var actual = transport.getMoneyType();
            //assert
            Assert.Equal(MoneyType.Persentage, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            ExpensesStander transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.getExpenses();
            //assert
            Assert.Equal(10, actual);
        }
        [Fact]
        public void Test5()
        {
            //arrange
            IExpenses transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.getMoneyType();
            //assert
            Assert.Equal(MoneyType.abslute, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            IExpenses transport = new ExpensesStander(MoneyType.abslute, 10);
            //act
            var actual = transport.getExpenses();
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
            var actual = expensesList[0].getExpenses();
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
            var t1 = manager.countainExpensesType(ExpensesType.Administrative);
            var t2 = manager.countainExpensesType(ExpensesType.Transport);
            var t3 = manager.countainExpensesType(ExpensesType.Packaging);
            var t4 = manager.isEmpty();
            var t5 = manager.removeExpensesType(ExpensesType.Packaging);
            var t6 = manager.isEmpty();
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
            var t1 = manager.countainExpensesType(ExpensesType.Administrative);
            var t2 = manager.countainExpensesType(ExpensesType.Transport);
            var t3 = manager.countainExpensesType(ExpensesType.Packaging);
            var t4 = manager.isEmpty();
            var t5 = manager.removeExpensesType(ExpensesType.Packaging);
            var t6 = manager.isEmpty();
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
            var t1 = manager.countainExpensesType(ExpensesType.Administrative);
            var t2 = manager.countainExpensesType(ExpensesType.Transport);
            var t3 = manager.countainExpensesType(ExpensesType.Packaging);
            var t4 = manager.isEmpty();
            var t5 = manager.removeExpensesType(ExpensesType.Packaging);
            var t6 = manager.isEmpty();
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
            var t3 = manager.getExpensesByType(ExpensesType.Administrative);
            //assert
            Assert.True(t1);
            Assert.False(t2);
            Assert.Equal(20, t3.getExpenses());
        }
        [Fact]
        public void Test12()
        {
            //arrange
            var dictionary = new Dictionary<ExpensesType, IExpenses>();
            dictionary.Add(ExpensesType.Packaging, new ExpensesStander(MoneyType.Persentage, 13));
            var manager = new ExpensesManager(dictionary);
            //act
            var t1 = manager.updateOrAddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 20));
            var t2 = manager.updateOrAddExpensesType(ExpensesType.Administrative, new ExpensesStander(MoneyType.Persentage, 22));
            var t3 = manager.getExpensesByType(ExpensesType.Administrative);
            //assert
            Assert.True(t1);
            Assert.True(t2);
            Assert.Equal(22, t3.getExpenses());
        }
        [Fact]
        public void Test13()
        {
            //arrange
            ExpensesStander c = new ExpensesStander(MoneyType.abslute, 4);
            //act
            var actual = c.FindExpenses(100);
            //assert
            Assert.Equal(4, c.getExpenses());
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
            Assert.Equal(20, actual);
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
            var actual = manager.findPackaging(100);
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
            var actual = manager.findPackaging(56);
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
            var actual = manager.findTransport(100);
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
            var actual = manager.findTransport(56);
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
            var actual = manager.findAdministrative(100);
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
            var actual = manager.findAdministrative(56);
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
            var actual = manager.findPackaging(56);
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
            product book = new product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.Name;
            //assert
            Assert.Equal("The Little Prince", actual);
        }
        [Fact]
        public void Test2()
        {
            //arrange
            product book = new product("The Little Prince", 12345, 20.25);
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
            product book = new product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.Price;
            //assert
            Assert.Equal(20.25, actual);
        }
        [Fact]
        public void Test4()
        {
            //arrange
            product book = new product("The Little Prince", 12345, 20.25);
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
            product book = new product("The Little Prince", 12345, 20.25);
            //act
            var actual = book.UPCCode;
            //assert
            Assert.Equal(12345, actual);
        }
        [Fact]
        public void Test6()
        {
            //arrange
            product book = new product("The Little Prince", 12345, 20.25);
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
            product book = new product("The Little Prince", 12345, 20.25);
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
            var str = Tools.CurrencyToString(type);
            //assert
            Assert.Equal("USD", str);
        }
        [Fact]
        public void CurrencyToString_JPY()
        {
            //arrange
            var type = CurrencyType.JPY;
            //act
            var str = Tools.CurrencyToString(type);
            //assert
            Assert.Equal("JPY", str);
        }
        [Fact]
        public void CurrencyToString_GBP()
        {
            //arrange
            var type = CurrencyType.GBP;
            //act
            var str = Tools.CurrencyToString(type);
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
            result = Tools.RoundInternalResult(result);
            //assert
            Assert.Equal(12.3457, result);
        }

        [Fact]
        public void RoundExternalResult()
        {
            //arrange
            var result = 12.34567;
            //act
            result = Tools.RoundExternalResult(result);
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
            var tax = Tools.FindTaxInternal(taxPersentage, cost);
            //assert
            Assert.Equal(2.025, tax);
        }
    }
    public class CommonTools_GetEnumValues
    {

    }





}
