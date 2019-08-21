using System.Threading.Tasks;
using InventoryDetailModels = Order.Product.InventoryDetail.DataAccessObjects.Models;

namespace Order.Product.InventoryDetail.DataAccessObjects
{
    internal interface IInventoryDetailDAO
    {
        Task<InventoryDetailModels.InventoryDetail> AddInventoryDetailAsync(InventoryDetailModels.InventoryDetail itemToAdd);
        Task DeleteInventoryDetailAsync(long id);
        Task<InventoryDetailModels.InventoryDetail> GetInventoryDetailAsync(long id);
        Task UpdateInventoryDetailAsync(long id, InventoryDetailModels.InventoryDetail itemToUpdate);
    }

}