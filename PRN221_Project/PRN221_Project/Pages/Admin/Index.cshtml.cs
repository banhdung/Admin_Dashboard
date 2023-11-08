using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using System.Data;

namespace PRN221_Project.Pages.Admin
{


    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;
        public IndexModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }
        public double daysRevenue { get; set; }
        public double monthsRevenue { get; set; }
        public List<Invoice> invoices { get; set; }
        public List<Invoice> recentInvoices { get; set; }

        public List<Customer> customers {get; set; }
        public List<Product> hotProduct { get; set; }   
        public double dayRevenue(DateTime day)
        {
            daysRevenue = 0;
            invoices = _context.Invoices.ToList();

            foreach (var invoice in invoices)
            {

                if (invoice.DateRecorded == day)
                {
                    daysRevenue += invoice.TotalAmount;
                }       
            }
            return daysRevenue;
        }

        public double monthRevenue(DateTime month)
        {
            monthsRevenue = 0;
            invoices = _context.Invoices.ToList();

            foreach (var invoice in invoices)
            {

                if (invoice.DateRecorded.Date.Month == month.Month)
                {
                    monthsRevenue += invoice.TotalAmount;
                }
            }
            return monthsRevenue;
        }



        public IActionResult OnGet()
        {
            customers = _context.Customers.ToList();
            recentInvoices = _context.Invoices.Include(x =>x.Customer).OrderByDescending(x => x.DateRecorded).Take(5).ToList(); 
          


            string ?userCookie = Request.Cookies["Role"];
            if (userCookie.Equals("1"))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/login");
            }

        }
    }
}