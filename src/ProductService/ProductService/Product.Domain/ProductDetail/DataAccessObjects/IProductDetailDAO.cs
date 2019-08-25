using Product.Domain.ProductDetail.DataAccessObjects.Entitys;

namespace Product.Domain.ProductDetail.DataAccessObjects
{
    internal interface IProductDetailDAO
    {
        ProductDetailEntity AddProduct(ProductDetailEntity productToAdd);
        void DeleteProduct(ProductDetailEntity productToDelete);
        ProductDetailEntity GetProduct(long id);
        ProductDetailEntity UpdateProduct(ProductDetailEntity productToUpdate);
    }
}