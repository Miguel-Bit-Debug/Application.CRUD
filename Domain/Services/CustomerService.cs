using Domain.Events;
using Domain.Interfaces.Customers;
using Domain.Models.Customer;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPublishEndpoint _publisher;

        public CustomerService(ICustomerRepository customerRepository,
                               IPublishEndpoint publish)
        {
            _customerRepository = customerRepository;
            _publisher = publish;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _publisher.Publish<CustomerCreateEvent>(new
            {
                Id = customer.Id,
                Name = customer.Name,
                CreatedAt = DateTime.Now
            });

            await _customerRepository.CreateCustomer(customer);
        }
    }
}
