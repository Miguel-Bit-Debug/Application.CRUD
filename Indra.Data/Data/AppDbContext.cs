using Domain.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
