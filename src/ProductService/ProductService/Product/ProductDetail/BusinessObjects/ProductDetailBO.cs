using Product.ProductDetail.DataAccessObjects;
using ProductDetailModels = Product.ProductDetail.BusinessObjects.Models;

namespace Product.ProductDetail.BusinessObjects
{
    internal class ProductDetailBO : IProductDetailBO
    {
        private readonly IProductDetailDAO _productDetailDAO;

        public ProductDetailBO(IProductDetailDAO productDetailDAO)
        {
            _productDetailDAO = productDetailDAO;
        }

        public ProductDetailModels.ProductDetail AddProduct(ProductDetailModels.ProductDetail productToAdd)
        {
            return _productDetailDAO.AddProduct(new DataAccessObjects.Models.ProductDetail(productToAdd))
                                    .ConvertToBusinessObject();
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

        public ProductDetailModels.ProductDetail GetProduct(long id)
        {
            return _productDetailDAO.GetProduct(id)
                                    .ConvertToBusinessObject();
        }

        public ProductDetailModels.ProductDetail UpdateProduct(ProductDetailModels.ProductDetail productToUpdate)
        {
            return _productDetailDAO.UpdateProduct(new DataAccessObjects.Models.ProductDetail(productToUpdate))
                                    .ConvertToBusinessObject();
        }
    }
}
