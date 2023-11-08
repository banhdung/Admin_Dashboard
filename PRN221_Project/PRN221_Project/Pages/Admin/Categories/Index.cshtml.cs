using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public IndexModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductCategories != null)
            {
                ProductCategory = await _context.ProductCategories.ToListAsync();
            }
        }
    }
}
