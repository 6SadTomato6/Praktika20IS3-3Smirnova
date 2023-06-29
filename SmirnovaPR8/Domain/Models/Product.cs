using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            PriceChanges = new HashSet<PriceChange>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductCount { get; set; }
        public int? CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<PriceChange> PriceChanges { get; set; }
    }
}
