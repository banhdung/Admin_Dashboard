using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        [BindProperty(SupportsGet = true)]
        public string? SearchKeyword { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? daySearch { get; set; }

        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public IndexModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoices != null)
            {
                Invoice = await _context.Invoices
                .Include(i => i.Account)
                .Include(i => i.Customer).ToListAsync();
                if (!String.IsNullOrEmpty(SearchKeyword) && daySearch.HasValue)
                {
                    Invoice = _context.Invoices.Where(x => x.Customer.CustomerName.Contains(SearchKeyword)).Where(x => x.DateRecorded == daySearch).ToList();
                }
                else if (String.IsNullOrEmpty(SearchKeyword) && daySearch.HasValue)
                {
                    Invoice = _context.Invoices.Where(x => x.DateRecorded == daySearch).ToList();
                }
                else if (!String.IsNullOrEmpty(SearchKeyword) && !daySearch.HasValue)
                {
                    Invoice = _context.Invoices.Where(x => x.Customer.CustomerName.Contains(SearchKeyword)).ToList();
                }
                else
                {
                    Invoice = await _context.Invoices
              .Include(i => i.Account)
              .Include(i => i.Customer).ToListAsync();
                }
                int total = Invoice.Count();
                countPages = (int)Math.Ceiling((double)total / ITEMS_PER_PAGE);
                if (currentPage < 1) currentPage = 1;
                if (currentPage > countPages) currentPage = countPages;
            }
        }


    }
}
