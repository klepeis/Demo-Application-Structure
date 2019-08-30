using Order.Domain.Infrastructure;
using Order.Domain.OrderDetails.DataAccessObjects.DataModels.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Domain.OrderDetails.DataAccessObjects
{
    internal class OrderDetailsDAO : IOrderDetailsDAO
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderDetailsDAO(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public OrderDetailEntity GetOrderDetail(long id)
        {
            return _orderDbContext.OrderDetails.Find(id);
        }

        public IEnumerable<OrderDetailEntity> GetAllOrdersForCustomer(long customerId, DateTime startDate, DateTime endDate)
        {
            return _orderDbContext.OrderDetails.Where(o => o.CustomerId == customerId
                && (o.CreatedDate.Date >= startDate.Date && o.CreatedDate <= endDate.Date));
        }
    }
}
