using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Supplliers
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public CreateModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Suppliers == null || Supplier == null)
            {
                return Page();
            }
            if (_context.Suppliers.Where(x => x.SupplierCode == Supplier.SupplierCode) != null)
            {
                TempData["error"] = "Supplier Code existed";
                return Redirect("/admin/suppliers/create");
            }

            _context.Suppliers.Add(Supplier);
            await _context.SaveChangesAsync();
            TempData["success"] = "Create successfully";

            return RedirectToPage("./Index");
        }
    }
}
