using System;
using System.Collections.Generic;

namespace PRN221_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ReceiveProducts = new HashSet<ReceiveProduct>();
            Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int? UnitId { get; set; }
        public int? CategoryId { get; set; }
        public double? UnitInStock { get; set; }
        public double? UnitPrice { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? ReorderLevel { get; set; }
        public int? AccountId { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductUnit Unit { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ReceiveProduct> ReceiveProducts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
