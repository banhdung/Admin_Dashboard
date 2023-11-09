using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Admin.Employee
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
        public Account Account { get; set; } = default!;
        

       
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Accounts == null || Account == null)
            {
                return Page();
            }
            Account.Role = 2; 
            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();
            TempData["success"] = "Create successfully";

            return RedirectToPage("./Index");
        }
    }
}
