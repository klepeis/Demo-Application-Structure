using Product.Domain.InventoryComponent.BusinessObjects.BusinessModels;
using Product.Domain.InventoryComponent.DataAccessObjects;
using Product.Domain.InventoryComponent.DataAccessObjects.DataModels.Entities;
using System;

namespace Product.Domain.InventoryComponent.BusinessObjects
{
    internal class InventoryBO : IInventoryBO
    {
        private readonly IInventoryDAO _inventoryDetailDAO;

        public InventoryBO(IInventoryDAO inventoryDetailDAO)
        {
            _inventoryDetailDAO = inventoryDetailDAO ?? throw new ArgumentNullException(nameof(inventoryDetailDAO));
        }

        public Inventory AddInventoryDetail(Inventory itemToAdd)
        {
            return _inventoryDetailDAO.AddInventoryDetail(new InventoryEntity(itemToAdd))
                                      .ConvertToBusinessModel();
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

        public Inventory GetInventoryDetail(long id)
        {
            return _inventoryDetailDAO.GetInventoryDetail(id)
                                    .ConvertToBusinessModel();
        }

        public Inventory UpdateInventoryDetail(Inventory itemToUpdate)
        {
            return _inventoryDetailDAO.UpdateInventoryDetail(new InventoryEntity(itemToUpdate))
                                      .ConvertToBusinessModel();
        }
    }
}
