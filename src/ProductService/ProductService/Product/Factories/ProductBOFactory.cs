namespace Product.Factories
{
    internal class ProductBOFactory : IProductBOFactory
    {
        private readonly IProductDAOFactory _productDAOFactory;

        public ProductBOFactory(IProductDAOFactory productDAOFactory)
        {
            _productDAOFactory = productDAOFactory;
        }
    }
}
