﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.OrderDetails.BusinessObjects;
using Order.OrderDetails.BusinessObjects.Models;
using Order.Product.InventoryDetail.BusinessObjects;
using System.Collections.Generic;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsBO _orderDetailsBO;
        private readonly IInventoryDetailBO _inventoryDetailBO;

        public OrderDetailsController(IOrderDetailsBO orderDetailsBO, IInventoryDetailBO inventoryDetailBO)
        {
            _orderDetailsBO = orderDetailsBO;
            _inventoryDetailBO = inventoryDetailBO;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(OrderDetail), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDetail> GetOrderDetail(long id)
        {
            OrderDetail returnValue = _orderDetailsBO.GetOrderDetail(id);
            if(returnValue == null)
            {
                return NotFound();
            }
            return Ok(returnValue);
        }

        // POST: api/OrderDetails
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
