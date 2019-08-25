using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.ProductDetail.BusinessObjects;
using Product.Domain.ProductDetail.BusinessObjects.DTOs;
using System;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailBO _productDetailBO;

        public ProductDetailsController(IProductDetailBO productDetailBO)
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
        [ProducesResponseType(typeof(ProductDetailDTO), StatusCodes.Status200OK)]
        public ActionResult<ProductDetailDTO> GetProductDetail(long id)
        {
            return Ok(_productDetailBO.GetProduct(id));
        }

        // POST: api/ProductDetails
        [HttpPost]
        [ProducesResponseType(typeof(ProductDetailDTO), StatusCodes.Status201Created)]
        public ActionResult<ProductDetailDTO> Post([FromBody] ProductDetailDTO productToAdd)
        {
            ProductDetailDTO newProduct = _productDetailBO.AddProduct(productToAdd);
            return CreatedAtAction(nameof(GetProductDetail), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/ProductDetails/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(long id, [FromBody] ProductDetailDTO productToUpdate)
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
