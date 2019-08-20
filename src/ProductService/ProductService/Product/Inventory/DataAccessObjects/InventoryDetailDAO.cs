using Microsoft.EntityFrameworkCore;
using Product.Infrastructure.DbContexts;
using Product.Inventory.DataAccessObjects.Models;

namespace Product.Inventory.DataAccessObjects
{
    internal class InventoryDetailDAO : IInventoryDetailDAO
    {
        private readonly ProductDbContext _productDbContext;

        public InventoryDetailDAO(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public InventoryDetail AddInventoryDetail(InventoryDetail itemToAdd)
        {
            _productDbContext.InventoryDetails.Add(itemToAdd);
            _productDbContext.SaveChanges();
            return itemToAdd;
        }

        public void DeleteInventoryDetail(InventoryDetail itemToDelete)
        {
            _productDbContext.InventoryDetails.Remove(itemToDelete);
            _productDbContext.SaveChanges();
        }

        public InventoryDetail GetInventoryDetail(long id)
        {
            return _productDbContext.InventoryDetails.Find(id);
        }

        public InventoryDetail UpdateInventoryDetail(InventoryDetail itemToUpdate)
        {
            _productDbContext.Entry(itemToUpdate).State = EntityState.Modified;
            _productDbContext.SaveChanges();

            return itemToUpdate;
        }
    }
}
