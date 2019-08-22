using Order.Product.InventoryDetail.DataAccessObjects;
using Order.Product.ProductDetail.DataAccessObjects;
using Product.Client.Inventory;
using Product.Client.ProductDetails;

namespace Order.Product.Factories
{
    internal class OrderProductDAOFactory : IOrderProductDAOFactory
    {
        private readonly IInventoryClient _inventoryClient;
        private readonly IProductDetailsClient _productDetailsClient;

        public OrderProductDAOFactory(IInventoryClient inventoryClient, IProductDetailsClient productDetailsClient)
        {
            _inventoryClient = inventoryClient;
            _productDetailsClient = productDetailsClient;
        }

        public IInventoryDetailDAO CreateInventoryDetailDAO()
        {
            return new InventoryDetailDAO(_inventoryClient);
        }

        public IProductDetailDAO CreateProductDetailDAO()
        {
            return new ProductDetailDAO(_productDetailsClient);
        }
    }
}
