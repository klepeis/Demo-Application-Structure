using Order.Domain.OrderDetails.DataAccessObjects.DataModels.Entitys;
using System;
using System.Collections.Generic;

namespace Order.Domain.OrderDetails.DataAccessObjects
{
    internal interface IOrderDetailsDAO
    {
        OrderDetailEntity GetOrderDetail(long id);
        IEnumerable<OrderDetailEntity> GetAllOrdersForCustomer(long customerId, DateTime startDate, DateTime endDate);
    }
}