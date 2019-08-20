using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Factories;
using Product.Infrastructure.DbContexts;
using Product.Inventory.BusinessObjects;
using Product.ProductDetail.BusinessObjects;

namespace Product.Extensions.DependencyInjection
{
    public static class ProductServiceCollectionExtensions
    {
        public static IServiceCollection RegisterProduct(this IServiceCollection services)
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
