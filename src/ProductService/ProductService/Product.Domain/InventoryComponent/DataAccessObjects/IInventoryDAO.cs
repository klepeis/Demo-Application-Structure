using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.InventoryComponent.DataAccessObjects
{
    internal interface IInventoryDAO
    {
        InventoryEntity AddInventoryDetail(InventoryEntity itemToAdd);
        void DeleteInventoryDetail(InventoryEntity itemToDelete);
        InventoryEntity GetInventoryDetail(long id);
        InventoryEntity UpdateInventoryDetail(InventoryEntity itemToUpdate);
    }
}