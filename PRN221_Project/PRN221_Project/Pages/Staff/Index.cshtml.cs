using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Project.Pages.Staff
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            string userCookie = Request.Cookies["Role"];
            if (userCookie.Equals("2"))
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
