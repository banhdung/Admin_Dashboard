using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }
        
        public int CustomerId { get; set; }
        public string CustomerCode { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        public string CustomerName { get; set; }
        [MaxLength(15)]
        [MinLength(1)]
        public string Contact { get; set; }
        [MaxLength(100)]
        [MinLength(1)]
        public string Address { get; set; }
        public int? Point { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
