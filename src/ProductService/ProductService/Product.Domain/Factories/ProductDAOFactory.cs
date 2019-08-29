using Product.Domain.Infrastructure;
using Product.Domain.Inventory.DataAccessObjects;
using Product.Domain.Product.DataAccessObjects;
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
