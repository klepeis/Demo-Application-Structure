using Product.Domain.Inventory.BusinessObjects.DTOs;
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

        public InventoryDetailDTO AddInventoryDetail(InventoryDetailDTO itemToAdd)
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

        public InventoryDetailDTO GetInventoryDetail(long id)
        {
            return _inventoryDetailDAO.GetInventoryDetail(id)
                                    .ConvertToDTO();
        }

        public InventoryDetailDTO UpdateInventoryDetail(InventoryDetailDTO itemToUpdate)
        {
            return _inventoryDetailDAO.UpdateInventoryDetail(new InventoryDetailEntity(itemToUpdate))
                                      .ConvertToDTO();
        }
    }
}
