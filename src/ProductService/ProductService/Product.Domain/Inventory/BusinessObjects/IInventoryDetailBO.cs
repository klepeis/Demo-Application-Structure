using Product.Domain.Inventory.BusinessObjects.BusinessModels;

namespace Product.Domain.Inventory.BusinessObjects
{
    public interface IInventoryDetailBO
    {
        InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd);
        void DeleteInventoryDetail(long id);
        InventoryDetail GetInventoryDetail(long id);
        InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate);
    }
}