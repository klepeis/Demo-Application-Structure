using Product.Inventory.DataAccessObjects.Models;

namespace Product.Inventory.DataAccessObjects
{
    internal interface IInventoryDetailDAO
    {
        InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd);
        void DeleteInventoryDetail(InventoryDetail itemToDelete);
        InventoryDetail GetInventoryDetail(long id);
        InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate);
    }
}