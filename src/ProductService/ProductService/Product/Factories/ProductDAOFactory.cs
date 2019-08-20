using Product.Infrastructure.DbContexts;
using Product.Inventory.DataAccessObjects;
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

        public IInventoryDetailDAO CreateInventoryDetailDAO()
        {
            return new InventoryDetailDAO(_productDbContext);
        }

        public IProductDetailDAO CreateProductDetailDAO()
        {
            return new ProductDetailDAO(_productDbContext);
        }
    }
}
