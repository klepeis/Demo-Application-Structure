using Order.Customer.Profile.BusinessObjects;
using Order.OrderDetails.BusinessObjects;

namespace Order.Factories
{
    internal class OrderBOFactory : IOrderBOFactory
    {
        private readonly ICustomerProfileBO _customerProfileBO;
        private readonly IOrderDAOFactory _orderDAOFactory;

        public OrderBOFactory(IOrderDAOFactory orderDAOFactory, ICustomerProfileBO customerProfileBO)
        {
            _orderDAOFactory = orderDAOFactory;
            _customerProfileBO = customerProfileBO;
        }

        public IOrderDetailsBO CreateOrderDetailsBO()
        {
            return new OrderDetailsBO(_orderDAOFactory.CreateOrderDetailsDAO());
        }
    }
}
