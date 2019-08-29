using Product.Domain.Inventory.BusinessObjects.BusinessModels;
using Product.Domain.Inventory.DataAccessObjects;
using Product.Domain.Inventory.DataAccessObjects.Entitys;
using System;

namespace Product.Domain.Inventory.BusinessObjects
{
    internal class InventoryDetailBO : IInventoryDetailBO
    {
        private readonly IInventoryDetailDAO _inventoryDetailDAO;

        public InventoryDetailBO(IInventoryDetailDAO inventoryDetailDAO)
        {
            _inventoryDetailDAO = inventoryDetailDAO ?? throw new ArgumentNullException(nameof(inventoryDetailDAO));
        }

        public InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd)
        {
            return _inventoryDetailDAO.AddInventoryDetail(new InventoryDetailEntity(itemToAdd))
                                      .ConvertToDTO();
        }

        public void DeleteInventoryDetail(long id)
        {
            var itemToDelete = _inventoryDetailDAO.GetInventoryDetail(id);

            if (itemToDelete == null)
            {
                //Handle Profile Not Found.
            }

            _inventoryDetailDAO.DeleteInventoryDetail(itemToDelete);
        }

        public InventoryDetail GetInventoryDetail(long id)
        {
            return _inventoryDetailDAO.GetInventoryDetail(id)
                                    .ConvertToDTO();
        }

        public InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate)
        {
            return _inventoryDetailDAO.UpdateInventoryDetail(new InventoryDetailEntity(itemToUpdate))
                                      .ConvertToDTO();
        }
    }
}
