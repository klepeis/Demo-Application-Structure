namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrderCustomerServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrderCustomer(this IServiceCollection services)
        {
            services.RegisterCustomerClient();

            return services;
        }
    }
}
