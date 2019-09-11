using Product.Domain.ProductComponent.DataAccessObjects;
using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;
using System;

namespace Product.Domain.ProductComponent.BusinessObjects
{
    internal class ProductBO : IProducBO
    {
        private readonly IProductDAO _productDetailDAO;

        public ProductBO(IProductDAO productDetailDAO)
        {
            _productDetailDAO = productDetailDAO ?? throw new ArgumentNullException(nameof(productDetailDAO));
        }

        public BusinessModels.Product AddProduct(BusinessModels.Product productToAdd)
        {
            return _productDetailDAO.AddProduct(new ProductEntity(productToAdd))
                                    .ConvertToBusinessModel();
        }

        public void DeleteProduct(long id)
        {
            var productToDelete = _productDetailDAO.GetProduct(id);

            if (productToDelete == null)
            {
                //Handle Profile Not Found.
            }

            _productDetailDAO.DeleteProduct(productToDelete);
        }

        public BusinessModels.Product GetProduct(long id)
        {
            return _productDetailDAO.GetProduct(id)
                                    .ConvertToBusinessModel();
        }

        public BusinessModels.Product UpdateProduct(BusinessModels.Product productToUpdate)
        {
            return _productDetailDAO.UpdateProduct(new ProductEntity(productToUpdate))
                                    .ConvertToBusinessModel();
        }
    }
}
