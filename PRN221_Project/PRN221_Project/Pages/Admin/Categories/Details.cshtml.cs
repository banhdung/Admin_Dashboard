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
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public DetailsModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

      public ProductCategory ProductCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }
    }
}
