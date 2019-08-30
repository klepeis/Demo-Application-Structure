using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Customer.Extensions.DependencyInjection;
using Order.Domain.Factories;
using Order.Domain.Infrastructure;
using Order.Domain.OrderDetails.BusinessObjects;
using Order.Product.Extensions.DependencyInjection;

namespace Order.Domain.Extensions.DependencyInjection
{
    public static class OrderServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrder(this IServiceCollection services)
        {
            services.RegisterOrderCustomer();
            services.RegisterOrderProduct();

            services.AddDbContext<OrderDbContext>(opt => 
            {
                opt.UseInMemoryDatabase(databaseName: "OrderDb");
            });

            services.AddScoped<IOrderDAOFactory, OrderDAOFactory>();
            services.AddScoped<IOrderBOFactory, OrderBOFactory>();

            services.AddScoped<IOrderDetailsBO>((sp) => 
            {
                return sp.GetRequiredService<IOrderBOFactory>().CreateOrderDetailsBO();
            });

            return services;
        }
    }
}
