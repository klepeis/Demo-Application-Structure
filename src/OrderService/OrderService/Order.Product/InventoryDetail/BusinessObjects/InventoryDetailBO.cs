using Order.Product.InventoryDetail.DataAccessObjects;

namespace Order.Product.InventoryDetail.BusinessObjects
{
    internal class InventoryDetailBO : IInventoryDetailBO
    {
        private readonly IInventoryDetailDAO _inventoryDetailDAO;

        public InventoryDetailBO(IInventoryDetailDAO inventoryDetailDAO)
        {
            _inventoryDetailDAO = inventoryDetailDAO;
        }
    }
}
