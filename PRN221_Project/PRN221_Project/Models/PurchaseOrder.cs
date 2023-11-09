using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Models
{
    public partial class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public int? ProductId { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? Quantity { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? UnitPrice { get; set; }
        [Range(0, 100000000, ErrorMessage = "Invalid Range")]
        public double? SubTotal { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
