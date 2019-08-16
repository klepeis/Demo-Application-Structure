using Microsoft.AspNetCore.Mvc;
using Order.OrderDetails.BusinessObjects;
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
        public string Get(int id)
        {
            return "value";
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
