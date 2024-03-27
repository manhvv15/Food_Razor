using System;
using System.Collections.Generic;

namespace G5Foods.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
