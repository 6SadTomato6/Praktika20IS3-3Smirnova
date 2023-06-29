using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PriceChange
    {
        public int ProductId { get; set; }
        public DateTime DatePriceChange { get; set; }
        public decimal NewPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
