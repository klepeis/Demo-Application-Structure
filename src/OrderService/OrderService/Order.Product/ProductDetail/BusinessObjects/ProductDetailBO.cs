using Order.Product.ProductDetail.DataAccessObjects;

namespace Order.Product.ProductDetail.BusinessObjects
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
