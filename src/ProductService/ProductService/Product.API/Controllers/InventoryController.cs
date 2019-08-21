using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Inventory.BusinessObjects;
using Product.Inventory.BusinessObjects.Models;
using System.Collections.Generic;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryDetailBO _inventoryDetailBO;

        public InventoryController(IInventoryDetailBO inventoryDetailBO)
        {
            _inventoryDetailBO = inventoryDetailBO;
        }

        //// GET: api/Inventory
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Inventory/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(InventoryDetail), StatusCodes.Status200OK)]
        public ActionResult<InventoryDetail> GetInventoryDetails(int id)
        {
            return Ok(_inventoryDetailBO.GetInventoryDetail(id));
        }

        // POST: api/Inventory
        [HttpPost]
        [ProducesResponseType(typeof(InventoryDetail), StatusCodes.Status201Created)]
        public ActionResult<InventoryDetail> Post([FromBody] InventoryDetail inventoryDetailToAdd)
        {
            InventoryDetail newInventoryDetail = _inventoryDetailBO.AddInventoryDetail(inventoryDetailToAdd);
            return CreatedAtAction(nameof(GetInventoryDetails), new { id = newInventoryDetail.ProductId }, newInventoryDetail);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(int id, [FromBody]  InventoryDetail inventoryDetailToUpdate)
        {
            if (id != inventoryDetailToUpdate.ProductId)
            {
                return BadRequest();
            }

            _inventoryDetailBO.UpdateInventoryDetail(inventoryDetailToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            //Somehow return NotFound;
            _inventoryDetailBO.DeleteInventoryDetail(id);

            return NoContent();
        }
    }
}
