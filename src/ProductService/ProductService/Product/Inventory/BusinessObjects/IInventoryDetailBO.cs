using Product.Inventory.BusinessObjects.Models;

namespace Product.Inventory.BusinessObjects
{
    public interface IInventoryDetailBO
    {
        InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd);
        void DeleteInventoryDetail(long id);
        InventoryDetail GetInventoryDetail(long id);
        InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate);
    }
}