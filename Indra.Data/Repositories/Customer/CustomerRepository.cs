using Domain.Interfaces.Customers;
using Infra.Data.Data;
using System.Threading.Tasks;

namespace Infra.Data.Repositories.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomer(Domain.Models.Customer.Customer customer)
        {
            await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
