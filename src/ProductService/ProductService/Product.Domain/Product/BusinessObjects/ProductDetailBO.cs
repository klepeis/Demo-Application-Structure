using Product.Domain.Product.BusinessObjects.BusinessModels;
using Product.Domain.Product.DataAccessObjects;
using Product.Domain.Product.DataAccessObjects.DataModels.Entitys;
using System;

namespace Product.Domain.Product.BusinessObjects
{
    internal class ProductDetailBO : IProductDetailBO
    {
        private readonly IProductDetailDAO _productDetailDAO;

        public ProductDetailBO(IProductDetailDAO productDetailDAO)
        {
            _productDetailDAO = productDetailDAO ?? throw new ArgumentNullException(nameof(productDetailDAO));
        }

        public ProductDetail AddProduct(BusinessModels.ProductDetail productToAdd)
        {
            return _productDetailDAO.AddProduct(new ProductDetailEntity(productToAdd))
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

        public ProductDetail GetProduct(long id)
        {
            return _productDetailDAO.GetProduct(id)
                                    .ConvertToBusinessModel();
        }

        public ProductDetail UpdateProduct(BusinessModels.ProductDetail productToUpdate)
        {
            return _productDetailDAO.UpdateProduct(new ProductDetailEntity(productToUpdate))
                                    .ConvertToBusinessModel();
        }
    }
}
