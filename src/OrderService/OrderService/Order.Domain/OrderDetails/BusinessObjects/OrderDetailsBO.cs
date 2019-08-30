using Order.Domain.OrderDetails.BusinessObjects.Models;
using Order.Domain.OrderDetails.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order.Domain.OrderDetails.BusinessObjects
{
    internal class OrderDetailsBO : IOrderDetailsBO
    {
        private readonly IOrderDetailsDAO _orderDetailsDAO;

        public OrderDetailsBO(IOrderDetailsDAO orderDetailsDAO)
        {
            _orderDetailsDAO = orderDetailsDAO;
        }

        public OrderDetail GetOrderDetail(long id)
        {
            return _orderDetailsDAO.GetOrderDetail(id)
                                   .ConvertToBusinessOjects();
        }

        public IEnumerable<OrderDetail> GetAllOrdersForCustomer(long customerId, DateTime? startDate = null, DateTime? endDate = null)
        {
            if(startDate == null)
            {
                startDate = DateTime.Now.AddDays(-90);
            }

            if(endDate == null)
            {
                endDate = DateTime.Now;
            }

            return _orderDetailsDAO.GetAllOrdersForCustomer(customerId, startDate.Value, endDate.Value)
                                   .Select(o => o.ConvertToBusinessOjects());
        }
    }
}
