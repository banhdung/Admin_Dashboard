using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public EditModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
           ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
           ViewData["UnitId"] = new SelectList(_context.ProductUnits, "UnitId", "UnitName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            Product.AccountId = 1;
            _context.Attach(Product).State = EntityState.Modified;
            if (_context.Products.FirstOrDefault(x => x.ProductName == Product.ProductName) != null)
            {
                TempData["error"] = "Product Name existed";
                return Redirect("/admin/products/edit?id="+Product.ProductId);
            }
            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = "Edit successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
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

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
