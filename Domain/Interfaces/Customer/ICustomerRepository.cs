using Domain.Models.Customer;
using System.Threading.Tasks;

namespace Domain.Interfaces.Customers
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
    }
}
