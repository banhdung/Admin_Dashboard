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
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.POSTContext _context;

        public DetailsModel(PRN221_Project.Models.POSTContext context)
        {
            _context = context;
        }

      public ReceiveProduct ReceiveProduct { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ReceiveProducts == null)
            {
                return NotFound();
            }

            var receiveproduct = await _context.ReceiveProducts.Include(x=>x.Product).Include(x => x.Supplier).Include(x =>x.Account).FirstOrDefaultAsync(m => m.ReceiveProductId == id);
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
    }
}
