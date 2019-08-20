using Product.Infrastructure.DbContexts;

namespace Product.Factories
{
    internal class ProductDAOFactory : IProductDAOFactory
    {
        private readonly ProductDbContext _productDbContext;

        public ProductDAOFactory(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
    }
}
