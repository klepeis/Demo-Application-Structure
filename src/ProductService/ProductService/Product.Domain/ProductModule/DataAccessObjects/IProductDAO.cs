using Product.Domain.ProductModule.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.ProductModule.DataAccessObjects
{
    internal interface IProductDAO
    {
        ProductEntity AddProduct(ProductEntity productToAdd);
        void DeleteProduct(ProductEntity productToDelete);
        ProductEntity GetProduct(long id);
        ProductEntity UpdateProduct(ProductEntity productToUpdate);
    }
}