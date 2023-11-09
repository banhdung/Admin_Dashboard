using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.ReceivieProducts
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public CreateModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        public Product product { get; set; }    

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Fullname");
        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
            return Page();
        }

        [BindProperty]
        public ReceiveProduct ReceiveProduct { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ReceiveProducts == null || ReceiveProduct == null)
            {
                return Page();
            }
            product = _context.Products.FirstOrDefault(x => x.ProductId == ReceiveProduct.ProductId);
            product.UnitInStock += ReceiveProduct.Quantity;
            _context.ReceiveProducts.Add(ReceiveProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
