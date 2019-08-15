namespace Customer.Profile.BusinessObjects.Models
{
    public class CustomerProfile
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
