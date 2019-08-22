using Order.Product.InventoryDetail.BusinessObjects;
using Order.Product.ProductDetail.BusinessObjects;

namespace Order.Product.Factories
{
    internal class OrderProductBOFactory : IOrderProductBOFactory
    {
        private readonly IOrderProductDAOFactory _orderProductDAOFactory;

        public OrderProductBOFactory(IOrderProductDAOFactory orderProductDAOFactory)
        {
            _orderProductDAOFactory = orderProductDAOFactory;
        }

        public IInventoryDetailBO CreateInventoryDetailBO()
        {
            return new InventoryDetailBO(_orderProductDAOFactory.CreateInventoryDetailDAO());
        }

        public IProductDetailBO CreateProductDetailBO()
        {
            return new ProductDetailBO(_orderProductDAOFactory.CreateProductDetailDAO());
        }
    }
}
