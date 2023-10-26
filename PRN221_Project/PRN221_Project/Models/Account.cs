using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PRN221_Project.Models
{
    public partial class Account 
    {
        public Account()
        {
            Invoices = new HashSet<Invoice>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
            ReceiveProducts = new HashSet<ReceiveProduct>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int? Designation { get; set; }
        public string Contact { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ReceiveProduct> ReceiveProducts { get; set; }
    }
}
