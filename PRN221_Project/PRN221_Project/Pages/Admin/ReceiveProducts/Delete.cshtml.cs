﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.ReceivieProducts
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public DeleteModel(PRN221_Project.Models.POSTContext context)
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

            var receiveproduct = await _context.ReceiveProducts.FirstOrDefaultAsync(m => m.ReceiveProductId == id);

            if (receiveproduct == null)
            {
                return NotFound();
            }
            else 
            {
                ReceiveProduct = receiveproduct;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ReceiveProducts == null)
            {
                return NotFound();
            }
            var receiveproduct = await _context.ReceiveProducts.FindAsync(id);

            if (receiveproduct != null)
            {
                ReceiveProduct = receiveproduct;
                _context.ReceiveProducts.Remove(ReceiveProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
