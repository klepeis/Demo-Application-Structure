﻿using Order.Domain.OrderDetails.SharedModels;
using System;

namespace Order.Domain.OrderDetails.BusinessObjects.Models
{
    public class OrderDetail
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedData { get; set; }
    }
}
