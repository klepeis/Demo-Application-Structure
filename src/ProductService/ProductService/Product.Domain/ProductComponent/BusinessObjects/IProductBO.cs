namespace Product.Domain.ProductComponent.BusinessObjects
{
    public interface IProducBO
    {
        BusinessModels.Product AddProduct(BusinessModels.Product productToAdd);
        void DeleteProduct(long id);
        BusinessModels.Product GetProduct(long id);
        BusinessModels.Product UpdateProduct(BusinessModels.Product productToUpdate);
    }
}