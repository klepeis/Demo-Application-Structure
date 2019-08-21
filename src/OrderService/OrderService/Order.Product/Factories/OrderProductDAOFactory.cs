using Order.Product.InventoryDetail.DataAccessObjects;
using Product.Client.Inventory;

namespace Order.Product.Factories
{
    internal class OrderProductDAOFactory : IOrderProductDAOFactory
    {
        private readonly IInventoryClient _inventoryClient;

        public OrderProductDAOFactory(IInventoryClient inventoryClient)
        {
            _inventoryClient = inventoryClient;
        }

        public IInventoryDetailDAO CreateInventoryDetailDAO()
        {
            return new InventoryDetailDAO(_inventoryClient);
        }
    }
}
