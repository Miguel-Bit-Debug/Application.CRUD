using Domain.Models.Product;

namespace Domain.Validators
{
    public class ProductValidator
    {
        public bool IsProductValid(ProductModel product)
        {
            if(string.IsNullOrWhiteSpace(product.Description) || string.IsNullOrWhiteSpace(product.Name))
            {
                return false;
            }

            return true;
        }
    }
}
