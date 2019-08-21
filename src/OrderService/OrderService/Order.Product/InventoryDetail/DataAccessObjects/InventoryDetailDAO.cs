using Product.Client.Inventory;
using System.Threading.Tasks;
using InventoryDetailModels = Order.Product.InventoryDetail.DataAccessObjects.Models;

namespace Order.Product.InventoryDetail.DataAccessObjects
{
    internal class InventoryDetailDAO : IInventoryDetailDAO
    {
        private readonly IInventoryClient _inventoryClient;

        public InventoryDetailDAO(IInventoryClient inventoryClient)
        {
            _inventoryClient = inventoryClient;
        }

        public async Task<InventoryDetailModels.InventoryDetail> AddInventoryDetailAsync(InventoryDetailModels.InventoryDetail itemToAdd)
        {
            return await _inventoryClient.AddInventoryDetailAsync<InventoryDetailModels.InventoryDetail>(itemToAdd);
        }

        public async Task DeleteInventoryDetailAsync(long id)
        {
            await _inventoryClient.DeleteInventoryDetailAsync(id);
        }

        public async Task<InventoryDetailModels.InventoryDetail> GetInventoryDetailAsync(long id)
        {
            return await _inventoryClient.GetInventoryDetailAsync<InventoryDetailModels.InventoryDetail>(id);
        }

        public async Task UpdateInventoryDetailAsync(long id, InventoryDetailModels.InventoryDetail itemToUpdate)
        {
            await _inventoryClient.UpdateInventoryDetailAsync(id, itemToUpdate);
        }
    }
}