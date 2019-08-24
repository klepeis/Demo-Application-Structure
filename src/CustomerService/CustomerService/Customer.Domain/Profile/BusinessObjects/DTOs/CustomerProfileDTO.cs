using System;
using System.Collections.Generic;

namespace Customer.Domain.Profile.BusinessObjects.DTOs
{
    public class CustomerProfileDTO : IEqualityComparer<CustomerProfileDTO>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool Equals(CustomerProfileDTO x, CustomerProfileDTO y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.CreatedDate.Equals(y.CreatedDate) && Nullable.Equals(x.ModifiedDate, y.ModifiedDate);
        }

        public int GetHashCode(CustomerProfileDTO obj)
        {
            unchecked
            {
                var hashCode = obj.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.LastName != null ? obj.LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.CreatedDate.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.ModifiedDate.GetHashCode();
                return hashCode;
            }
        }
    }
}
