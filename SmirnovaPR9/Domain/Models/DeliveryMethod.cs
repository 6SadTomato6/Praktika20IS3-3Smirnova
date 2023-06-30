using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class DeliveryMethod
    {
        public int DeliveryMethodId { get; set; }
        public string DeliveryMethodName { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
