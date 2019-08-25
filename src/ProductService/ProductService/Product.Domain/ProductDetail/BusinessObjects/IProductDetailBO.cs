using Product.Domain.ProductDetail.BusinessObjects.DTOs;

namespace Product.Domain.ProductDetail.BusinessObjects
{
    public interface IProductDetailBO
    {
        ProductDetailDTO AddProduct(ProductDetailDTO productToAdd);
        void DeleteProduct(long id);
        ProductDetailDTO GetProduct(long id);
        ProductDetailDTO UpdateProduct(ProductDetailDTO productToUpdate);
    }
}