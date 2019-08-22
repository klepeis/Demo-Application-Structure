using Microsoft.Extensions.DependencyInjection;
using Order.Product.Factories;
using Order.Product.InventoryDetail.BusinessObjects;
using Order.Product.ProductDetail.BusinessObjects;
using Product.Client.Extensions.DependencyInjection;

namespace Order.Product.Extensions.DependencyInjection
{
    public static class OrderProducServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrderProduct(this IServiceCollection services)
        {
            services.RegisterProductClient();

            services.AddScoped<IOrderProductDAOFactory, OrderProductDAOFactory>();
            services.AddScoped<IOrderProductBOFactory, OrderProductBOFactory>();

            services.AddScoped<IInventoryDetailBO>((sp) =>
            {
                return sp.GetRequiredService<IOrderProductBOFactory>().CreateInventoryDetailBO();
            });

            services.AddScoped<IProductDetailBO>((sp) =>
            {
                return sp.GetRequiredService<IOrderProductBOFactory>().CreateProductDetailBO();
            });

            return services;
        }
    }
}
