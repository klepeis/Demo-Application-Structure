using Product.Domain.Product.DataAccessObjects.DataModels.Entitys;

namespace Product.Domain.Product.DataAccessObjects
{
    internal interface IProductDetailDAO
    {
        ProductDetailEntity AddProduct(ProductDetailEntity productToAdd);
        void DeleteProduct(ProductDetailEntity productToDelete);
        ProductDetailEntity GetProduct(long id);
        ProductDetailEntity UpdateProduct(ProductDetailEntity productToUpdate);
    }
}