using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Models
{
    public partial class ProductUnit
    {
        public ProductUnit()
        {
            Products = new HashSet<Product>();
        }

        public int UnitId { get; set; }
        [MaxLength(15)]
        [MinLength(1)]
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
