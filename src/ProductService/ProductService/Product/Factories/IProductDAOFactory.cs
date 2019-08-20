using Product.ProductDetail.DataAccessObjects;

namespace Product.Factories
{
    internal interface IProductDAOFactory
    {
        IProductDetailDAO CreateProductDetailDAO();
    }
}