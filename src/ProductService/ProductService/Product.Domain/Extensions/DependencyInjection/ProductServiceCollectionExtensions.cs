using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Factories;
using Product.Domain.Infrastructure;
using Product.Domain.Inventory.BusinessObjects;
using Product.Domain.ProductDetail.BusinessObjects;

namespace Product.Domain.Extensions.DependencyInjection
{
    public static class ProductServiceCollectionExtensions
    {
        public static IServiceCollection RegisterProductDomain(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(databaseName: "ProductDb");
            });

            services.AddScoped<IProductDAOFactory, ProductDAOFactory>();
            services.AddScoped<IProductBOFactory, ProductBOFactory>();

            services.AddScoped<IInventoryDetailBO>((sp) =>
            {
                return sp.GetRequiredService<IProductBOFactory>().CreateInventoryDetailBO();
            });

            services.AddScoped<IProductDetailBO>((sp) => 
            {
                return sp.GetRequiredService<IProductBOFactory>().CreateProductDetailBO();
            });

            return services;
        }
    }
}
