using ProductDetailModels = Product.ProductDetail.BusinessObjects.Models;

namespace Product.ProductDetail.BusinessObjects
{
    public interface IProductDetailBO
    {
        ProductDetailModels.ProductDetail AddProduct(ProductDetailModels.ProductDetail productToAdd);
        void DeleteProduct(long id);
        ProductDetailModels.ProductDetail GetProduct(long id);
        ProductDetailModels.ProductDetail UpdateProduct(ProductDetailModels.ProductDetail productToUpdate);
    }
}