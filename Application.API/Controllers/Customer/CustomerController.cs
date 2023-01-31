using Domain.Interfaces.Customers;
using Domain.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.API.Controllers.Customers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            await _customerService.CreateCustomer(customer);

            return Ok();
        }
    }
}
