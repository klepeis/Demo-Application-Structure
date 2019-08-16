using Order.Infrastructure.DbContexts;
using Order.OrderDetails.DataAccessObjects;

namespace Order.Factories
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
