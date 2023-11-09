using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.ReceivieProducts
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchKeyword { get; set; }

        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }
        public IndexModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        public IList<ReceiveProduct> ReceiveProduct { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ReceiveProducts != null)
            {
                ReceiveProduct = await _context.ReceiveProducts
                .Include(i => i.Account)
                .Include(i => i.Supplier).Include(i => i.Product).ToListAsync();
                if (!String.IsNullOrEmpty(SearchKeyword))
                {
                    ReceiveProduct = _context.ReceiveProducts.Where(x => x.Supplier.SupplierName.Contains(SearchKeyword)).ToList();
                }
                int total = ReceiveProduct.Count();
                countPages = (int)Math.Ceiling((double)total / ITEMS_PER_PAGE);
                if (currentPage < 1) currentPage = 1;
                if (currentPage > countPages) currentPage = countPages;
            }
        }
    }
}
