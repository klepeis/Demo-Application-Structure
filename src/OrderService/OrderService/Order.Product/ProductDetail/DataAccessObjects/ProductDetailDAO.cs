using Product.Client.ProductDetails;
using System.Threading.Tasks;
using ProductDetailModels = Order.Product.ProductDetail.DataAccessObjects.Models;

namespace Order.Product.ProductDetail.DataAccessObjects
{
    internal class ProductDetailDAO : IProductDetailDAO
    {
        private readonly IProductDetailsClient _productDetailClient;

        public ProductDetailDAO(IProductDetailsClient productDetailClient)
        {
            _productDetailClient = productDetailClient;
        }

        public async Task<ProductDetailModels.ProductDetail> AddProductDetailAsync(ProductDetailModels.ProductDetail productDetailToAdd)
        {
            return await _productDetailClient.AddProductAsync<ProductDetailModels.ProductDetail>(productDetailToAdd);
        }

        public async Task DeleteProductDetailAsync(long id)
        {
            await _productDetailClient.DeleteProductAsync(id);
        }

        public async Task<ProductDetailModels.ProductDetail> GetProductDetailAsync(long id)
        {
            return await _productDetailClient.GetProductAsync<ProductDetailModels.ProductDetail>(id);
        }

        public async Task UpdateProductDetailAsync(long id, ProductDetailModels.ProductDetail updatedProduct)
        {
            await _productDetailClient.UpdateProductAsync(id, updatedProduct);
        }
    }
}
