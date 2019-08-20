using Product.Infrastructure.DbContexts;
using Product.ProductDetail.DataAccessObjects;

namespace Product.Factories
{
    internal class ProductDAOFactory : IProductDAOFactory
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDAOFactory(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public IProductDetailDAO CreateProductDetailDAO()
        {
            return new ProductDetailDAO(_productDbContext);
        }
    }
}
