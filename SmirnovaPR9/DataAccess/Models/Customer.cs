using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int CustomerId { get; set; }
        public string CustomerFname { get; set; } = null!;
        public string CustomerLname { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
