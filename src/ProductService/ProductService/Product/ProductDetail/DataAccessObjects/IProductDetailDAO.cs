using ProductDetailModels = Product.ProductDetail.DataAccessObjects.Models;

namespace Product.ProductDetail.DataAccessObjects
{
    internal interface IProductDetailDAO
    {
        ProductDetailModels.ProductDetail AddProduct(ProductDetailModels.ProductDetail productToAdd);
        void DeleteProduct(ProductDetailModels.ProductDetail productToDelete);
        ProductDetailModels.ProductDetail GetProduct(long id);
        ProductDetailModels.ProductDetail UpdateProduct(ProductDetailModels.ProductDetail productToUpdate);
    }
}