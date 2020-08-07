using PriceCalculator.PriceCalculator.Enums;
using PriceCalculator.PriceCalculator.Utilities;

namespace PriceCalculator.PriceCalculator.Discount
{
    public static class DiscountExtension
    {
        public static double FindDiscount(double discount, double cost)
        {
            return (MathUtilities.PercentageDivider(discount * cost));
        }
        public static double FindDiscountBeforeTaxAplay(this DiscountManager value, int UCP, double cost)
        {
            var discountType = value.GetDiscountByType(DiscountType.UPCDiscountBeforeTaxApply);
            if (discountType == null)
            {
                return 0;
            }
            return MathUtilities.RoundExternalResult(FindDiscount(discountType.GetDiscount(UCP), cost));
        }
        public static double FindDiscountafterTaxAplayAdditive(this DiscountManager value, int UCP, double cost)
        {
            var result = 0.0;
            var discountType = value.GetDiscountByType(DiscountType.UniversalDiscount);
            if (discountType == null) { result += 0; } else { result += discountType.GetDiscount(); }
            discountType = value.GetDiscountByType(DiscountType.UPCDiscountAfterTaxApply);
            if (discountType == null) { result += 0; } else { result += discountType.GetDiscount(UCP); }
            return MathUtilities.RoundExternalResult(FindDiscount(result, cost));
        }
        public static double FindDiscountafterTaxAplayMultiplicative(this DiscountManager value, int UCP, double cost)
        {
            var result = FindDiscountForUniversalMember(value.GetDiscountByType(DiscountType.UniversalDiscount), cost);
            cost -= result;
            result += FindDiscountforUPCMember(value.GetDiscountByType(DiscountType.UPCDiscountAfterTaxApply), cost, UCP);
            return MathUtilities.RoundExternalResult(result);
        }
        private static double FindDiscountForUniversalMember(IDiscount discount, double cost)
        {
            if (discount == null)
            {
                return 0;
            }
            return FindDiscount(discount.GetDiscount(), cost);
        }
        private static double FindDiscountforUPCMember(IDiscount discount, double cost, int upc)
        {
            if (discount == null)
            {
                return 0;
            }
            return FindDiscount(discount.GetDiscount(upc), cost);
        }
    }
}