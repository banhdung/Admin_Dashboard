using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace PRN221_Project.Pages.Admin
{
    

    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            string userCookie = Request.Cookies["Role"];
            if (userCookie.Equals("1"))
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/login");
            }
        }
    }
}
