using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CartDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
