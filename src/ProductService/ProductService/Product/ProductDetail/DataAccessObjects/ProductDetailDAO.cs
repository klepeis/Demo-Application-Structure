using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.DbContexts;
using ProductDetailModels = Product.ProductDetail.DataAccessObjects.Models;

namespace Product.ProductDetail.DataAccessObjects
{
    internal class ProductDetailDAO : IProductDetailDAO
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDetailDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public ProductDetailModels.ProductDetail AddProduct(ProductDetailModels.ProductDetail productToAdd)
        {
            _productDbContext.Products.Add(productToAdd);
            _productDbContext.SaveChanges();
            return productToAdd;
        }

        public void DeleteProduct(ProductDetailModels.ProductDetail productToDelete)
        {
            _productDbContext.Products.Remove(productToDelete);
            _productDbContext.SaveChanges();
        }

        public ProductDetailModels.ProductDetail GetProduct(long id)
        {
            return _productDbContext.Products.Find(id);
        }

        public ProductDetailModels.ProductDetail UpdateProduct(ProductDetailModels.ProductDetail productToUpdate)
        {
            _productDbContext.Entry(productToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return productToUpdate;
        }
    }
}
