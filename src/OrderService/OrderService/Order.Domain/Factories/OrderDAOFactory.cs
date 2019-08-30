using Order.Domain.Infrastructure;
using Order.Domain.OrderDetails.DataAccessObjects;

namespace Order.Domain.Factories
{
    internal class OrderDAOFactory : IOrderDAOFactory
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderDAOFactory(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public IOrderDetailsDAO CreateOrderDetailsDAO()
        {
            return new OrderDetailsDAO(_orderDbContext);
        }
    }
}
