using Microsoft.Extensions.DependencyInjection;
using Product.Client.Inventory;
using Product.Client.ProductDetails;
using System;

namespace Product.Client.Extensions.DependencyInjection
{
    public static class ProductClientServiceCollectionExtensions
    {
        public static IServiceCollection RegisterProductClient(this IServiceCollection services)
        {
            services.AddHttpClient<IInventoryClient, InventoryClient>(c =>
            {
                c.BaseAddress = new Uri("");
            });

            services.AddHttpClient<IProductDetailsClient, ProductDetailsClient>(c =>
            {
                c.BaseAddress = new Uri("");
            });

            return services;
        }
    }
}
