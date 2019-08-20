using Product.ProductDetail.DataAccessObjects;

namespace Product.ProductDetail.BusinessObjects
{
    internal class ProductDetailBO : IProductDetailBO
    {
        private readonly IProductDetailDAO _productDetailDAO;

        public ProductDetailBO(IProductDetailDAO productDetailDAO)
        {
            _productDetailDAO = productDetailDAO;
        }
    }
}
