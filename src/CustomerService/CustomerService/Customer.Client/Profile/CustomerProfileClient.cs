using System.Net.Http;
using System.Threading.Tasks;
using Customer.Client.Profile.Models;
using HttpHelpers;

namespace Customer.Client.Profile
{
    public class CustomerProfileClient : BaseHttpClient, ICustomerProfileClient
    {

        public CustomerProfileClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<CustomerProfile> AddCustomerProfileAsync(CustomerProfile profileToAdd)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Post, $"api/Profile", profileToAdd);
            return await SendHttpRequestMessageAsync<CustomerProfile>(request);
        }

        public async Task DeleteCustomerProfileAsync(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Delete, $"api/Profile/{id}");
            await SendHttpRequestMessageAsync(request);
        }

        public async Task<CustomerProfile> GetCustomerProfileAsync(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Get, $"api/Profile/{id}");
            return await SendHttpRequestMessageAsync<CustomerProfile>(request);
        }

        public async Task UpdateCustomerProfileAsync(long id, CustomerProfile profileToUpdate)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Put, $"api/Profile/{id}", profileToUpdate);
            await SendHttpRequestMessageAsync(request);
        }
    }


}
