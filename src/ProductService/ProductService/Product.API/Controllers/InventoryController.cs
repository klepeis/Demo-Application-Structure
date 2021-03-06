﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.InventoryModule.BusinessObjects;
using Product.Domain.InventoryModule.BusinessObjects.BusinessModels;
using System;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryBO _inventoryDetailBO;

        public InventoryController(IInventoryBO inventoryDetailBO)
        {
            _inventoryDetailBO = inventoryDetailBO ?? throw new ArgumentNullException(nameof(inventoryDetailBO));
        }

        //// GET: api/Inventory
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status200OK)]
        public ActionResult<Inventory> GetInventoryDetails(int id)
        {
            return Ok(_inventoryDetailBO.GetInventoryDetail(id));
        }

        // POST: api/Inventory
        [HttpPost]
        [ProducesResponseType(typeof(Inventory), StatusCodes.Status201Created)]
        public ActionResult<Inventory> Post([FromBody] Inventory inventoryDetailToAdd)
        {
            Inventory newInventoryDetail = _inventoryDetailBO.AddInventoryDetail(inventoryDetailToAdd);
            return CreatedAtAction(nameof(GetInventoryDetails), new { id = newInventoryDetail.ProductId }, newInventoryDetail);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(int id, [FromBody]  Inventory inventoryDetailToUpdate)
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
