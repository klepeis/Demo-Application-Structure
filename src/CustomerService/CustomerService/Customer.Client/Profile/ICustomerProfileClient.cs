using System;
using System.Threading.Tasks;

namespace Customer.Client.Profile
{
    public interface ICustomerProfileClient
    {
        Task<TResponse> AddCustomerProfileAsync<TResponse>(Object profileToAdd);
        Task DeleteCustomerProfileAsync(long id);
        Task<TResponse> GetCustomerProfileAsync<TResponse>(long id);
        Task UpdateCustomerProfileAsync(long id, Object profileToUpdate);
    }
}