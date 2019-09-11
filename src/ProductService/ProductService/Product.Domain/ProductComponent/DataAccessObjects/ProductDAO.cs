using Microsoft.EntityFrameworkCore;
using Product.Domain.Infrastructure;
using Product.Domain.ProductComponent.DataAccessObjects.DataModels.Entities;
using System;

namespace Product.Domain.ProductComponent.DataAccessObjects
{
    internal class ProductDAO : IProductDAO
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }

        public ProductEntity AddProduct(ProductEntity productToAdd)
        {
            _productDbContext.Products.Add(productToAdd);
            _productDbContext.SaveChanges();
            return productToAdd;
        }

        public void DeleteProduct(ProductEntity productToDelete)
        {
            _productDbContext.Products.Remove(productToDelete);
            _productDbContext.SaveChanges();
        }

        public ProductEntity GetProduct(long id)
        {
            return _productDbContext.Products.Find(id);
        }

        public ProductEntity UpdateProduct(ProductEntity productToUpdate)
        {
            _productDbContext.Entry(productToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return productToUpdate;
        }
    }
}
