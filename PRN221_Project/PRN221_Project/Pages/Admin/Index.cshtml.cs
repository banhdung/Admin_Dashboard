using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public double Revenue { get; set; }
        public List<Invoice> invoices { get; set; }

        public double dayRevenue(DateTime day)
        {
            Revenue = 0;
            invoices = _context.Invoices.ToList();

            foreach (var invoice in invoices)
            {

                if (invoice.DateRecorded == day)
                {
                    Revenue += invoice.TotalAmount;
                }       
            }
            return Revenue;
        }

        //public double mothRevenue(DateTime month)
        //{
        //    Revenue = 0;
        //    invoices = _context.Invoices.ToList();

        //    foreach (var invoice in invoices)
        //    {

        //        if (invoice.DateRecorded == month)
        //        {
        //            Revenue += invoice.TotalAmount;
        //        }
        //    }
        //    return Revenue;
        //}
        public IActionResult OnGet()
        {
           
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