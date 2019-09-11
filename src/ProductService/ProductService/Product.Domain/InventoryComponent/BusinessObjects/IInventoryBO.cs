using Product.Domain.InventoryComponent.BusinessObjects.BusinessModels;

namespace Product.Domain.InventoryComponent.BusinessObjects
{
    public interface IInventoryBO
    {
        Inventory AddInventoryDetail(Inventory itemToAdd);
        void DeleteInventoryDetail(long id);
        Inventory GetInventoryDetail(long id);
        Inventory UpdateInventoryDetail(Inventory itemToUpdate);
    }
}