using Microsoft.Extensions.DependencyInjection;
using Product.Client.Extensions.DependencyInjection;

namespace Order.Product.Extensions.DependencyInjection
{
    public static class OrderProducServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrderProduct(this IServiceCollection services)
        {
            services.RegisterProductClient();

            //services.AddScoped<IOrderCustomerDAOFactory, OrderCustomerDAOFactory>();
            //services.AddScoped<IOrderCustomerBOFactory, OrderCustomerBOFactory>();

            //services.AddScoped<ICustomerProfileBO>((sp) =>
            //{
            //    return sp.GetRequiredService<IOrderCustomerBOFactory>().CreateCustomerProfileBO();
            //});

            return services;
        }
    }
}
