using Product.Infrastructure.DbContexts;

namespace Product.ProductDetail.DataAccessObjects
{
    internal class ProductDetailDAO : IProductDetailDAO
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDetailDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
    }
}
