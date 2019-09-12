using Product.Domain.InventoryModule.BusinessObjects.BusinessModels;

namespace Product.Domain.InventoryModule.BusinessObjects
{
    public interface IInventoryBO
    {
        Inventory AddInventoryDetail(Inventory itemToAdd);
        void DeleteInventoryDetail(long id);
        Inventory GetInventoryDetail(long id);
        Inventory UpdateInventoryDetail(Inventory itemToUpdate);
    }
}