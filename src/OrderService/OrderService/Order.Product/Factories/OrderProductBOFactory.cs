using Order.Product.InventoryDetail.BusinessObjects;

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
    }
}
