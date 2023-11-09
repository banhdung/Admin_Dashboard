﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Products
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
        ViewData["CategoryId"] = new SelectList(_context.ProductCategories, "CategoryId", "CategoryName");
        ViewData["UnitId"] = new SelectList(_context.ProductUnits, "UnitId", "UnitName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if ( _context.Products == null || Product == null)
            {
                return Page();
            }
         if(_context.Products.Where( x => x.ProductCode == Product.ProductCode)!= null)
            {
                TempData["error"] = "Product Code existed";
                return Redirect("/admin/products/create");
            }
            Product.AccountId = 1;
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
