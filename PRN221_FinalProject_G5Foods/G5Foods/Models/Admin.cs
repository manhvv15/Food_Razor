using System;
using System.Collections.Generic;

namespace G5Foods.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Orders = new HashSet<Order>();
        }

        public int AdminId { get; set; }
        public string? AdminName { get; set; }
        public string? AdminEmail { get; set; }
        public string? AdminPassword { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
