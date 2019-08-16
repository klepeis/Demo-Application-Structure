using Order.OrderDetails.BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace Order.OrderDetails.BusinessObjects
{
    public interface IOrderDetailsBO
    {
        OrderDetail GetOrderDetail(long id);
        IEnumerable<OrderDetail> GetAllOrdersForCustomer(long customerId, DateTime? startDate = null, DateTime? endDate = null);
    }
}