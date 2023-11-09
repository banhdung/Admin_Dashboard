using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private ICustomerService customerService;

        public IndexModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (customerService.GetAllCustomer != null)
            {
               Customer = customerService.GetAllCustomer(); 
            }
        }
    }
}
