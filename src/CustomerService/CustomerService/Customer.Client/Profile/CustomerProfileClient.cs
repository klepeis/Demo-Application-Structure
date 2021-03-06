﻿using HttpHelpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Customer.Client.Profile
{
    public class CustomerProfileClient : BaseHttpClient, ICustomerProfileClient
    {

        public CustomerProfileClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<TResponse> AddCustomerProfileAsync<TResponse>(Object profileToAdd)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Post, $"api/Profile", profileToAdd);
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task DeleteCustomerProfileAsync(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Delete, $"api/Profile/{id}");
            await SendHttpRequestMessageAsync(request);
        }

        public async Task<TResponse> GetCustomerProfileAsync<TResponse>(long id)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Get, $"api/Profile/{id}");
            return await SendHttpRequestMessageAsync<TResponse>(request);
        }

        public async Task UpdateCustomerProfileAsync(long id, Object profileToUpdate)
        {
            HttpRequestMessage request = CreateHttpRequestMessage(HttpMethod.Put, $"api/Profile/{id}", profileToUpdate);
            await SendHttpRequestMessageAsync(request);
        }
    }


}
