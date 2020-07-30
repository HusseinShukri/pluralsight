using PriceCalculator.CAP;
using PriceCalculator.Common;
namespace PriceCalculator.Discount
{
    public static class DiscountExtension
    {
        public static double FindDiscount(double discount, double cost)
        {
            return (Tools.PercentageDivider(discount * cost));
        }
        public static double FindDiscountBeforeTaxAplay(this DiscountManager value, int UCP, double cost)
        {
            var discountType = value.getDiscountByType(DiscountType.UPCDiscountBeforeTaxApply);
            if (discountType == null)
            {
                return 0;
            }
            return Tools.RoundExternalResult(FindDiscount(discountType.getDiscount(UCP), cost));
        }
        public static double FindDiscountafterTaxAplayAdditive(this DiscountManager value, int UCP, double cost)
        {
            var result = 0.0;
            var discountType = value.getDiscountByType(DiscountType.UniversalDiscount);
            if (discountType == null) { result += 0; } else { result += discountType.getDiscount(); }
            discountType = value.getDiscountByType(DiscountType.UPCDiscountAfterTaxApply);
            if (discountType == null) { result += 0; } else { result += discountType.getDiscount(UCP); }
            return Tools.RoundExternalResult(FindDiscount(result, cost));
        }
        public static double FindDiscountafterTaxAplayMultiplicative(this DiscountManager value, int UCP, double cost)
        {
            var result = getMemberUniversal(value.getDiscountByType(DiscountType.UniversalDiscount), cost);
            cost -= result;
            result += getMemberUPC(value.getDiscountByType(DiscountType.UPCDiscountAfterTaxApply), cost, UCP);
            return Tools.RoundExternalResult(result);
        }
        private static double getMemberUniversal(IDiscount discount1, double cost)
        {
            if (discount1 == null)
            {
                return 0;
            }
            return FindDiscount(discount1.getDiscount(), cost);
        }
        private static double getMemberUPC(IDiscount discount1, double cost, int upc)
        {
            if (discount1 == null)
            {
                return 0;
            }
            return FindDiscount(discount1.getDiscount(upc), cost);
        }
    }
}