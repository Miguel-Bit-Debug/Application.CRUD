using Domain.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task AddProduct(ProductModel product);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(int id, ProductModel product);
        Task<ProductModel> GetProductById(int id);
    }
}
