using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.ProductModule.BusinessObjects;
using Product.Domain.ProductModule.BusinessObjects.BusinessModels;
using System;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProducBO _productDetailBO;

        public ProductDetailsController(IProducBO productDetailBO)
        {
            _productDetailBO = productDetailBO ?? throw new ArgumentNullException(nameof(productDetailBO));
        }

        //// GET: api/ProductDetails
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.ProductModule.BusinessObjects.BusinessModels.Product), StatusCodes.Status200OK)]
        public ActionResult<Domain.ProductModule.BusinessObjects.BusinessModels.Product> GetProductDetail(long id)
        {
            return Ok(_productDetailBO.GetProduct(id));
        }

        // POST: api/ProductDetails
        [HttpPost]
        [ProducesResponseType(typeof(Domain.ProductModule.BusinessObjects.BusinessModels.Product), StatusCodes.Status201Created)]
        public ActionResult<Domain.ProductModule.BusinessObjects.BusinessModels.Product> Post([FromBody] Domain.ProductModule.BusinessObjects.BusinessModels.Product productToAdd)
        {
            Domain.ProductModule.BusinessObjects.BusinessModels.Product newProduct = _productDetailBO.AddProduct((Domain.ProductModule.BusinessObjects.BusinessModels.Product)productToAdd);
            return CreatedAtAction(nameof(GetProductDetail), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/ProductDetails/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(long id, [FromBody] Domain.ProductModule.BusinessObjects.BusinessModels.Product productToUpdate)
        {
            if (id != productToUpdate.Id)
            {
                return BadRequest();
            }

            _productDetailBO.UpdateProduct(productToUpdate);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            //Somehow return NotFound;
            _productDetailBO.DeleteProduct(id);

            return NoContent();
        }
    }
}
