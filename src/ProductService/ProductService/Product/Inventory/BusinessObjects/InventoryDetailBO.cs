using Product.Inventory.BusinessObjects.Models;
using Product.Inventory.DataAccessObjects;

namespace Product.Inventory.BusinessObjects
{
    internal class InventoryDetailBO : IInventoryDetailBO
    {
        private readonly IInventoryDetailDAO _inventoryDetailDAO;

        public InventoryDetailBO(IInventoryDetailDAO inventoryDetailDAO)
        {
            _inventoryDetailDAO = inventoryDetailDAO;
        }

        public InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd)
        {
            return _inventoryDetailDAO.AddInventoryDetail(new DataAccessObjects.Models.InventoryDetail(itemToAdd))
                                      .ConvertToBusinessObject();
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
                                    .ConvertToBusinessObject();
        }

        public InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate)
        {
            return _inventoryDetailDAO.UpdateInventoryDetail(new DataAccessObjects.Models.InventoryDetail(itemToUpdate))
                                      .ConvertToBusinessObject();
        }
    }
}
