using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.ProductDetail.BusinessObjects;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailBO _productDetailBO;

        public ProductDetailsController(IProductDetailBO productDetailBO)
        {
            _productDetailBO = productDetailBO;
        }

        //// GET: api/ProductDetails
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ProductDetails/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(ProductDetail.BusinessObjects.Models.ProductDetail), StatusCodes.Status200OK)]
        public ActionResult<ProductDetail.BusinessObjects.Models.ProductDetail> GetProductDetail(long id)
        {
            return Ok(_productDetailBO.GetProduct(id));
        }

        // POST: api/ProductDetails
        [HttpPost]
        [ProducesResponseType(typeof(ProductDetail.BusinessObjects.Models.ProductDetail), StatusCodes.Status201Created)]
        public ActionResult<ProductDetail.BusinessObjects.Models.ProductDetail> Post([FromBody] ProductDetail.BusinessObjects.Models.ProductDetail productToAdd)
        {
            ProductDetail.BusinessObjects.Models.ProductDetail newProduct = _productDetailBO.AddProduct(productToAdd);
            return CreatedAtAction(nameof(GetProductDetail), new { id = newProduct.Id }, newProduct);
        }

        // PUT: api/ProductDetails/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Put(long id, [FromBody] ProductDetail.BusinessObjects.Models.ProductDetail productToUpdate)
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
