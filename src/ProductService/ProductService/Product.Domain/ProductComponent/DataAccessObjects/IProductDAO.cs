using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;

namespace Product.Domain.ProductComponent.DataAccessObjects
{
    internal interface IProductDAO
    {
        ProductEntity AddProduct(ProductEntity productToAdd);
        void DeleteProduct(ProductEntity productToDelete);
        ProductEntity GetProduct(long id);
        ProductEntity UpdateProduct(ProductEntity productToUpdate);
    }
}