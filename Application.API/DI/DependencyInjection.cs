using Domain.Interfaces;
using Domain.Interfaces.Customers;
using Domain.Services;
using Infra.Data.Data;
using Infra.Data.Repositories;
using Infra.Data.Repositories.Customer;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.API.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["DefaultConnection"]);
            });

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, busConfig) =>
                {
                    busConfig.Host(configuration["RabbitMq"]);
                });
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
