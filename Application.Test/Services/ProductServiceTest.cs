using Domain.Interfaces;
using Domain.Models.Product;
using Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test.Services
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _respository;
        private IProductService _productService;

        public ProductServiceTest()
        {
            _respository = new Mock<IProductRepository>();
            _productService = new ProductService(_respository.Object);
        }

        [Fact]
        public async Task ListProduct()
        {
            _respository.Setup(x => x.GetAllProducts().Result).Returns(new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "teste",
                    Description = "teste"
                }
            });

            var products = await _productService.GetAllProducts();

            Assert.NotNull(products);
        }

    }
}
