using Domain.Interfaces;
using Domain.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(ProductModel product)
        {
            await _productRepository.AddProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var successDeleted = await _productRepository.DeleteProduct(id);
            if (!successDeleted)
                return false;

            return true;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products;
        }

        public Task<ProductModel> GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
                return null;
            return product;
        }

        public async Task<bool> UpdateProduct(int id, ProductModel product)
        {
            if (id != product.Id) return false;

            await _productRepository.UpdateProduct(id, product);
            return true;
        }
    }
}
