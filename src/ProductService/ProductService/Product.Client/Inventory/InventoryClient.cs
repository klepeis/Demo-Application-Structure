using HttpHelpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Product.Client.Inventory
{
    public class InventoryClient : BaseHttpClient, IInventoryClient
    {

        public InventoryClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<TResponse> AddInventoryDetailAsync<TResponse>(Object inventoryDetailToAdd)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Post, $"api/Inventory", inventoryDetailToAdd);
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task DeleteInventoryDetailAsync(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Delete, $"api/Inventory/{id}");
            await SendHttpRequestMessageAsync(request);
        }

        public async Task<TResponse> GetInventoryDetailAsync<TResponse>(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Get, $"api/Inventory/{id}");
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task UpdateInventoryDetailAsync(long id, Object inventoryDetailToUpdate)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Put, $"api/Inventory/{id}", inventoryDetailToUpdate);
            await SendHttpRequestMessageAsync(request);
        }
    }


}
