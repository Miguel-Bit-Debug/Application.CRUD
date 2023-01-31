using Domain.Models.Product;
using Infra.Data.Data;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test.Repository
{
    public class ProductRepositoryTest
    {
        private readonly ProductRepository _productRepository;
        private readonly AppDbContext _context;

        public ProductRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging();
            var options = optionsBuilder.Options;

            _context = new AppDbContext(options);
            _productRepository = new ProductRepository(_context);
        }

        [Fact]
        public void Deve_Testar_Instancia_Repository()
        {
            var repository = new ProductRepository(_context);
            Assert.True(repository != null);
        }


        [Fact]
        public async Task Deve_AdicionarProduto()
        {
            var product = new ProductModel()
            {
                Id = 1,
                Name = "teste",
                Description = "teste"
            };

            var products = await _productRepository.GetAllProducts();

            var x = 10;

        }

    }
}
