using Customer.Factories;
using Customer.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
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

            return services;
        }
    }
}
