using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.ReceivieProducts
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public EditModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReceiveProduct ReceiveProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReceiveProducts == null)
            {
                return NotFound();
            }

            var receiveproduct =  await _context.ReceiveProducts.FirstOrDefaultAsync(m => m.ReceiveProductId == id);
            if (receiveproduct == null)
            {
                return NotFound();
            }
            ReceiveProduct = receiveproduct;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
           ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
           ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReceiveProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiveProductExists(ReceiveProduct.ReceiveProductId))
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

        private bool ReceiveProductExists(int id)
        {
          return (_context.ReceiveProducts?.Any(e => e.ReceiveProductId == id)).GetValueOrDefault();
        }
    }
}
