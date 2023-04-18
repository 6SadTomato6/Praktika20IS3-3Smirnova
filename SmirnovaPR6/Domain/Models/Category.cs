using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int FilterId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Filter Filter { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
