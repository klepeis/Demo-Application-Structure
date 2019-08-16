using Microsoft.Extensions.DependencyInjection;
using Order.Customer.Extensions.DependencyInjection;

namespace Order.Extensions.DependencyInjection
{
    public static class OrderServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrder(this IServiceCollection services)
        {
            services.RegisterOrderCustomer();

            return services;
        }
    }
}
