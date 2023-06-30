using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Filter
    {
        public Filter()
        {
            Categories = new HashSet<Category>();
        }

        public int FilterId { get; set; }
        public string FilterName { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
