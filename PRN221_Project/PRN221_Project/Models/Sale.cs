using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Models
{
    public partial class Sale
    {
        public int SalesId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? Quantity { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? UnitPrice { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? SubTotal { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
