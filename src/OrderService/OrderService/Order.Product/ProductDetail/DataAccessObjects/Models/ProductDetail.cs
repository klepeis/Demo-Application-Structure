namespace Order.Product.ProductDetail.DataAccessObjects.Models
{
    internal class ProductDetail
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
