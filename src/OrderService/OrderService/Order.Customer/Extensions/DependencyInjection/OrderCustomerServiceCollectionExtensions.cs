using Customer.Client.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Customer.Factories;
using Order.Customer.Infrastructure.DbContexts;
using Order.Customer.Profile.BusinessObjects;

namespace Order.Customer.Extensions.DependencyInjection
{
    public static class OrderCustomerServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrderCustomer(this IServiceCollection services)
        {
            services.AddDbContext<CustomerDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName:"OrderCustomerDatabase");
            });

            services.RegisterCustomerClient();

            services.AddScoped<IOrderCustomerDAOFactory, OrderCustomerDAOFactory>();
            services.AddScoped<IOrderCustomerBOFactory, OrderCustomerBOFactory>();

            services.AddScoped<ICustomerProfileBO>((sp) =>
            {
                return sp.GetRequiredService<IOrderCustomerBOFactory>().CreateCustomerProfileBO();
            });

            return services;
        }
    }
}
