using Customer.Client.Profile;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomerClientServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCustomerClient(this IServiceCollection services)
        {
            services.AddHttpClient<ICustomerProfileClient, CustomerProfileClient>(c =>
            {
                c.BaseAddress = new Uri("");
            });

            return services;
        }
    }
}
