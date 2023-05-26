using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Delivery
    {
        public int CartId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int DeliveryMethodId { get; set; }
        public string DeliveryStatus { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ShoppingCart Cart { get; set; } = null!;
        public virtual DeliveryMethod DeliveryMethod { get; set; } = null!;
    }
}
