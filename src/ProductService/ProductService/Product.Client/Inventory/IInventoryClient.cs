using System;
using System.Threading.Tasks;

namespace Product.Client.Inventory
{
    public interface IInventoryClient
    {
        Task<TResponse> AddInventoryDetailAsync<TResponse>(Object inventoryDetailToAdd);
        Task DeleteInventoryDetailAsync(long id);
        Task<TResponse> GetInventoryDetailAsync<TResponse>(long id);
        Task UpdateInventoryDetailAsync(long id, Object inventoryDetailToUpdate);
    }
}