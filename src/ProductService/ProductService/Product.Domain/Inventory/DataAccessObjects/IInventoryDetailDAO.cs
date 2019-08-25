using Product.Domain.Inventory.DataAccessObjects.Entitys;

namespace Product.Domain.Inventory.DataAccessObjects
{
    internal interface IInventoryDetailDAO
    {
        InventoryDetailEntity AddInventoryDetail(InventoryDetailEntity itemToAdd);
        void DeleteInventoryDetail(InventoryDetailEntity itemToDelete);
        InventoryDetailEntity GetInventoryDetail(long id);
        InventoryDetailEntity UpdateInventoryDetail(InventoryDetailEntity itemToUpdate);
    }
}