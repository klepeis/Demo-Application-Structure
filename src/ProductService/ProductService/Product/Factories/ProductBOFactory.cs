using Product.ProductDetail.BusinessObjects;

namespace Product.Factories
{
    internal class ProductBOFactory : IProductBOFactory
    {
        private readonly IProductDAOFactory _productDAOFactory;

        public ProductBOFactory(IProductDAOFactory productDAOFactory)
        {
            _productDAOFactory = productDAOFactory;
        }

        public IProductDetailBO CreateProductDetailBO()
        {
            return new ProductDetailBO(_productDAOFactory.CreateProductDetailDAO());
        }
    }
}
