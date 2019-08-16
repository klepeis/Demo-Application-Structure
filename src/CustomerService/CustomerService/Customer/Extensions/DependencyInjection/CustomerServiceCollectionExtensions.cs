using Customer.Factories;
using Customer.Infrastructure.DbContexts;
using Customer.Profile.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Extensions.DependencyInjection
{
    public static class CustomerServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCustomer(this IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName: "CustomerDb");
            });

            services.AddScoped<ICustomerDAOFactory, CustomerDAOFactory>();
            services.AddScoped<ICustomerBOFactory, CustomerBOFactory>();

            services.AddScoped<ICustomerProfileBO>((sp) =>
            {
                return sp.GetRequiredService<ICustomerBOFactory>().CreateCustomerProfileBO();
            });

            return services;
        }
    }
}
