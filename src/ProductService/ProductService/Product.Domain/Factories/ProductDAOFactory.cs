using Product.Domain.Infrastructure;
using Product.Domain.InventoryModule.DataAccessObjects;
using Product.Domain.ProductModule.DataAccessObjects;
using System;

namespace Product.Domain.Factories
{
    internal class ProductDAOFactory : IProductDAOFactory
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDAOFactory(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public IInventoryDAO CreateInventoryDetailDAO()
        {
            return new InventoryDAO(_productDbContext);
        }

        public IProductDAO CreateProductDetailDAO()
        {
            return new ProductDAO(_productDbContext);
        }
    }
}
