using Order.Domain.OrderDetails.BusinessObjects.Models;
using Order.Domain.OrderDetails.SharedModels;
using System;

namespace Order.Domain.OrderDetails.DataAccessObjects.DataModels.Entitys
{
    internal class OrderDetailEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedData { get; set; }

        internal OrderDetail ConvertToBusinessOjects()
        {
            return new OrderDetail()
            {
                CreatedDate = this.CreatedDate,
                CustomerId = this.CustomerId,
                Id = this.Id,
                ModifiedData = this.ModifiedData,
                OrderStatus = this.OrderStatus
            };
        }
    }
}
