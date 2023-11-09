using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ReceiveProducts = new HashSet<ReceiveProduct>();
        }

        public int SupplierId { get; set; }
        [MaxLength(15)]
        [MinLength(1)]
        public string SupplierCode { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public string SupplierName { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public string SupplierContact { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public string SupplierAddress { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        [EmailAddress]
        public string SupplierEmail { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ReceiveProduct> ReceiveProducts { get; set; }
    }
}
