using Order.OrderDetails.DataAccessObjects.Models;
using System;
using System.Collections.Generic;

namespace Order.OrderDetails.DataAccessObjects
{
    internal interface IOrderDetailsDAO
    {
        OrderDetail GetOrderDetail(long id);
        IEnumerable<OrderDetail> GetAllOrdersForCustomer(long customerId, DateTime startDate, DateTime endDate);
    }
}