using Product.Domain.ProductDetail.BusinessObjects.DTOs;
using Product.Domain.ProductDetail.DataAccessObjects;
using Product.Domain.ProductDetail.DataAccessObjects.Entitys;

namespace Product.Domain.ProductDetail.BusinessObjects
{
    internal class ProductDetailBO : IProductDetailBO
    {
        private readonly IProductDetailDAO _productDetailDAO;

        public ProductDetailBO(IProductDetailDAO productDetailDAO)
        {
            _productDetailDAO = productDetailDAO;
        }

        public ProductDetailDTO AddProduct(ProductDetailDTO productToAdd)
        {
            return _productDetailDAO.AddProduct(new ProductDetailEntity(productToAdd))
                                    .ConvertToDTO();
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

        public ProductDetailDTO GetProduct(long id)
        {
            return _productDetailDAO.GetProduct(id)
                                    .ConvertToDTO();
        }

        public ProductDetailDTO UpdateProduct(ProductDetailDTO productToUpdate)
        {
            return _productDetailDAO.UpdateProduct(new ProductDetailEntity(productToUpdate))
                                    .ConvertToDTO();
        }
    }
}
