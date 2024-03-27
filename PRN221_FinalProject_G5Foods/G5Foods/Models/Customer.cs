﻿using System;
using System.Collections.Generic;

namespace G5Foods.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
