using Domain.Models.Customer;
using System.Threading.Tasks;

namespace Domain.Interfaces.Customers
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
    }
}
