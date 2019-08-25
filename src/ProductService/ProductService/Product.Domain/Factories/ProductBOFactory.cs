﻿using Product.Domain.Inventory.BusinessObjects;
using Product.Domain.ProductDetail.BusinessObjects;

namespace Product.Domain.Factories
{
    internal class ProductBOFactory : IProductBOFactory
    {
        private readonly IProductDAOFactory _productDAOFactory;

        public ProductBOFactory(IProductDAOFactory productDAOFactory)
        {
            _productDAOFactory = productDAOFactory;
        }

        public IInventoryDetailBO CreateInventoryDetailBO()
        {
            return new InventoryDetailBO(_productDAOFactory.CreateInventoryDetailDAO());
        }

        public IProductDetailBO CreateProductDetailBO()
        {
            return new ProductDetailBO(_productDAOFactory.CreateProductDetailDAO());
        }
    }
}