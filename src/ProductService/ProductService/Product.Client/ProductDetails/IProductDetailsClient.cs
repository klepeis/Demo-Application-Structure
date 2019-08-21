using System;
using System.Threading.Tasks;

namespace Product.Client.ProductDetails
{
    public interface IProductDetailsClient
    {
        Task<TResponse> AddCustomerProfileAsync<TResponse>(Object profileToAdd);
        Task DeleteCustomerProfileAsync(long id);
        Task<TResponse> GetCustomerProfileAsync<TResponse>(long id);
        Task UpdateCustomerProfileAsync(long id, Object profileToUpdate);
    }
}