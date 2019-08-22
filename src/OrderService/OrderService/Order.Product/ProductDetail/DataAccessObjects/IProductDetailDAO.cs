using System.Threading.Tasks;
using ProductDetailModels = Order.Product.ProductDetail.DataAccessObjects.Models;

namespace Order.Product.ProductDetail.DataAccessObjects
{
    internal interface IProductDetailDAO
    {
        Task<ProductDetailModels.ProductDetail> AddProductDetailAsync(ProductDetailModels.ProductDetail productDetailToAdd);
        Task DeleteProductDetailAsync(long id);
        Task<ProductDetailModels.ProductDetail> GetProductDetailAsync(long id);
        Task UpdateProductDetailAsync(long id, ProductDetailModels.ProductDetail updatedProductDetail);
    }
}