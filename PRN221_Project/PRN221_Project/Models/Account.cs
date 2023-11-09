using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [MaxLength(30 , ErrorMessage ="must be less than 30 ")]
        [MinLength(5)]
        public string Username { get; set; }
        public string Password { get; set; }

        [StringLength(30,MinimumLength = 0)]
        public string Fullname { get; set; }
        public int? Designation { get; set; }

        [EmailAddress(ErrorMessage ="Email not valid")]
        public string Contact { get; set; }
        public int? Role { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ReceiveProduct> ReceiveProducts { get; set; }
    }
}
