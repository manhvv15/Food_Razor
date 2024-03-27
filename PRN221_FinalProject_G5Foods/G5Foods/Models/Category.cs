using System;
using System.Collections.Generic;

namespace G5Foods.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
