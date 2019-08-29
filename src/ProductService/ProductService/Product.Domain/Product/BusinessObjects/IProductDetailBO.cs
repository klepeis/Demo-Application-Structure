using Product.Domain.Product.BusinessObjects.BusinessModels;

namespace Product.Domain.Product.BusinessObjects
{
    public interface IProductDetailBO
    {
        ProductDetail AddProduct(BusinessModels.ProductDetail productToAdd);
        void DeleteProduct(long id);
        ProductDetail GetProduct(long id);
        ProductDetail UpdateProduct(BusinessModels.ProductDetail productToUpdate);
    }
}