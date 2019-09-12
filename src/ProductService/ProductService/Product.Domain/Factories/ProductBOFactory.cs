using Product.Domain.InventoryModule.BusinessObjects;
using Product.Domain.ProductModule.BusinessObjects;
using System;

namespace Product.Domain.Factories
{
    internal class ProductBOFactory : IProductBOFactory
    {
        private readonly IProductDAOFactory _productDAOFactory;

        public ProductBOFactory(IProductDAOFactory productDAOFactory)
        {
            _productDAOFactory = productDAOFactory ?? throw new ArgumentNullException(nameof(productDAOFactory));
        }

        public IInventoryBO CreateInventoryDetailBO()
        {
            return new InventoryBO(_productDAOFactory.CreateInventoryDetailDAO());
        }

        public IProducBO CreateProductDetailBO()
        {
            return new ProductBO(_productDAOFactory.CreateProductDetailDAO());
        }
    }
}
