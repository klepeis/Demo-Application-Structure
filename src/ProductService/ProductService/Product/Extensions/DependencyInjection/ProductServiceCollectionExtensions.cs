using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Factories;
using Product.Infrastructure.DbContexts;

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

            return services;
        }
    }
}
