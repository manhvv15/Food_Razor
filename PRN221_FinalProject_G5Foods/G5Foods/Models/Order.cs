using System;
using System.Collections.Generic;

namespace G5Foods.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public int? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipPhone { get; set; }
        public int? Address { get; set; }
        public int? AdminId { get; set; }

        public virtual Address? AddressNavigation { get; set; }
        public virtual Admin? Admin { get; set; }
        public virtual Customer? Customer { get; set; } = null!;
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
