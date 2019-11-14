namespace CsharpAdvancedMosh.Generics.Constraints
{
    //Constraint: Class type
    //Passed type can be Product class or it's subtypes
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }
}
