using System;
using System.Threading.Tasks;

namespace Product.Client.ProductDetails
{
    public interface IProductDetailsClient
    {
        Task<TResponse> AddProductAsync<TResponse>(Object profileToAdd);
        Task DeleteProductAsync(long id);
        Task<TResponse> GetProductAsync<TResponse>(long id);
        Task UpdateProductAsync(long id, Object profileToUpdate);
    }
}