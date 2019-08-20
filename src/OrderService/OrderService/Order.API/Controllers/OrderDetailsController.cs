using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.OrderDetails.BusinessObjects;
using Order.OrderDetails.BusinessObjects.Models;
using System.Collections.Generic;

namespace Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsBO _orderDetailsBO;

        public OrderDetailsController(IOrderDetailsBO orderDetailsBO)
        {
            _orderDetailsBO = orderDetailsBO;
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
