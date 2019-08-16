using Order.OrderDetails.SharedModels;
using System;

namespace Order.OrderDetails.DataAccessObjects.Models
{
    internal class OrderDetail
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedData { get; set; }

        internal BusinessObjects.Models.OrderDetail ConvertToBusinessOjects()
        {
            return new BusinessObjects.Models.OrderDetail()
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
