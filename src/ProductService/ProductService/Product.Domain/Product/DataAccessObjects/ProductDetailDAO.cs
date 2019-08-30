using Microsoft.EntityFrameworkCore;
using Product.Domain.Infrastructure;
using Product.Domain.Product.DataAccessObjects.DataModels.Entitys;
using System;

namespace Product.Domain.Product.DataAccessObjects
{
    internal class ProductDetailDAO : IProductDetailDAO
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDetailDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public ProductDetailEntity AddProduct(ProductDetailEntity productToAdd)
        {
            _productDbContext.Products.Add(productToAdd);
            _productDbContext.SaveChanges();
            return productToAdd;
        }

        public void DeleteProduct(ProductDetailEntity productToDelete)
        {
            _productDbContext.Products.Remove(productToDelete);
            _productDbContext.SaveChanges();
        }

        public ProductDetailEntity GetProduct(long id)
        {
            return _productDbContext.Products.Find(id);
        }

        public ProductDetailEntity UpdateProduct(ProductDetailEntity productToUpdate)
        {
            _productDbContext.Entry(productToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return productToUpdate;
        }
    }
}
