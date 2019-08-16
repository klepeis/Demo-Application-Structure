using Microsoft.Extensions.DependencyInjection;
using Order.Customer.Extensions.DependencyInjection;
using Order.Factories;

namespace Order.Extensions.DependencyInjection
{
    public static class OrderServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrder(this IServiceCollection services)
        {
            services.RegisterOrderCustomer();

            services.AddScoped<IOrderDAOFactory, OrderDAOFactory>();
            services.AddScoped<IOrderBOFactory, OrderBOFactory>();

            return services;
        }
    }
}
