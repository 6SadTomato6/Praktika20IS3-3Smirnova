using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class CartItem
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ShoppingCart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
