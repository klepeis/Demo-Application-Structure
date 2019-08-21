using HttpHelpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Product.Client.ProductDetails
{
    public class ProductDetailsClient : BaseHttpClient, IProductDetailsClient
    {

        public ProductDetailsClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<TResponse> AddProductAsync<TResponse>(Object productToAdd)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Post, $"api/ProductDetails", productToAdd);
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task DeleteProductAsync(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Delete, $"api/ProductDetails/{id}");
            await SendHttpRequestMessageAsync(request);
        }

        public async Task<TResponse> GetProductAsync<TResponse>(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Get, $"api/ProductDetails/{id}");
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task UpdateProductAsync(long id, Object productToUpdate)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Put, $"api/ProductDetails/{id}", productToUpdate);
            await SendHttpRequestMessageAsync(request);
        }
    }


}
