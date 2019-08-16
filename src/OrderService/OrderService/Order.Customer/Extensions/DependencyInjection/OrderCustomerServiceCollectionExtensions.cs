using Customer.Client.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Order.Customer.Factories;
using Order.Customer.Profile.BusinessObjects;

namespace Order.Customer.Extensions.DependencyInjection
{
    public static class OrderCustomerServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrderCustomer(this IServiceCollection services)
        {
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
