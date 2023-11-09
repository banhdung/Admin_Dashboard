using System;
using System.Collections.Generic;

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
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int? Point { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
