using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services;

namespace PRN221_Project.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public EditModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory =  await _context.ProductCategories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            ProductCategory = productcategory;
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            _context.Attach(ProductCategory).State = EntityState.Modified;
            if (_context.ProductCategories.FirstOrDefault(x => x.CategoryName == ProductCategory.CategoryName)!=null)
            {
                TempData["error"] = "Category Name existed";
                return Redirect("/admin/categories/edit?id="+ProductCategory.CategoryId);
            }
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = "Edit successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(ProductCategory.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductCategoryExists(int id)
        {
          return (_context.ProductCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
