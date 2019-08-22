namespace Order.Product.ProductDetail.BusinessObjects.Models
{
    public class ProductDetail
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
