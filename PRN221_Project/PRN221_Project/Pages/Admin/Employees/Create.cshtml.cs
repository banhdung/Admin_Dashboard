using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;
using PRN221_Project.Services;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Admin.Employee
{
    public class CreateModel : PageModel
    {


        private IAccountService accountService;

        public CreateModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;
        

       
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid )
            {
                return Page();
            }
            if (accountService.getAccountByUserName(Account.Username) != null)
            {
                TempData["error"] = "Username existed";
                return Page();

            }
            else
            {
                Account.Role = 2;
                accountService.AddAccount(Account);
                TempData["success"] = "Create successfully";
                return RedirectToPage("./Index");
            }
          

          
        }
    }
}
