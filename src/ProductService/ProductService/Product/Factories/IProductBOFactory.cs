using Product.ProductDetail.BusinessObjects;

namespace Product.Factories
{
    public interface IProductBOFactory
    {
        IProductDetailBO CreateProductDetailBO();
    }
}