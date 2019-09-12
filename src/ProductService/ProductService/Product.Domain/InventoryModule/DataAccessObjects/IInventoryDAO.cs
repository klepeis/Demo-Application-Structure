using Product.Domain.InventoryModule.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.InventoryModule.DataAccessObjects
{
    internal interface IInventoryDAO
    {
        InventoryEntity AddInventoryDetail(InventoryEntity itemToAdd);
        void DeleteInventoryDetail(InventoryEntity itemToDelete);
        InventoryEntity GetInventoryDetail(long id);
        InventoryEntity UpdateInventoryDetail(InventoryEntity itemToUpdate);
    }
}