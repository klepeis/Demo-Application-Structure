using Customer.Domain.Factories;
using Customer.Domain.Infrastructure;
using Customer.Domain.CustomerModule.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Domain.Extensions.DependencyInjection
{
    public static class CustomerServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCustomerDomain(this IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName: "CustomerDb");
            });

            services.AddScoped<ICustomerDAOFactory, CustomerDAOFactory>();
            services.AddScoped<ICustomerBOFactory, CustomerBOFactory>();

            services.AddScoped<ICustomerBO>((sp) =>
            {
                return sp.GetRequiredService<ICustomerBOFactory>().CreateCustomerProfileBO();
            });

            return services;
        }
    }
}
