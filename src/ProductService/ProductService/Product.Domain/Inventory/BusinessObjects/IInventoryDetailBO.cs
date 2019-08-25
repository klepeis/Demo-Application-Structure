using Product.Domain.Inventory.BusinessObjects.DTOs;

namespace Product.Domain.Inventory.BusinessObjects
{
    public interface IInventoryDetailBO
    {
        InventoryDetailDTO AddInventoryDetail(InventoryDetailDTO itemToAdd);
        void DeleteInventoryDetail(long id);
        InventoryDetailDTO GetInventoryDetail(long id);
        InventoryDetailDTO UpdateInventoryDetail(InventoryDetailDTO itemToUpdate);
    }
}