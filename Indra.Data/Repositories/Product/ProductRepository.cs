using Domain.Interfaces;
using Domain.Models.Product;
using Infra.Data.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProduct(ProductModel product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product == null)
                return false;

            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var products = _dbContext.Products.OrderBy(x => x.Name).ToList();
            return products;
        }

        public async Task<bool> UpdateProduct(int id, ProductModel product)
        {
            var oldProduct = await GetProductById(id);
            if (oldProduct == null)
                return false;

            _dbContext.Entry<ProductModel>(oldProduct).CurrentValues.SetValues(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
