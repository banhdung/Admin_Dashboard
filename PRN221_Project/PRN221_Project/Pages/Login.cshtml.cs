using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Models;
using PRN221_Project.Services;

namespace PRN221_Project.Pages.Admin
{
    public class LoginModel : PageModel
    {

        private readonly POSTContext _context;

        public LoginModel(POSTContext context)
        {
            _context = context;

        }
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }
        public IActionResult OnGet()
        {
            string? userCookie = Request.Cookies["Role"];
            if (userCookie != null && userCookie.Equals("1"))
            {
                return RedirectToPage("/admin/index");
            }

            else if (userCookie != null && userCookie.Equals("2"))
            {
                return RedirectToPage("/staff/index");
            }
        
            else
            {
                return Page();
    }



        }

        public IActionResult OnPost()
        {
            AccountService accountService = new AccountService(_context);
            Account account = accountService.getAccountByUserNameAndPassword(Username, Password);
            if (account != null)
            {
                TempData["success"] = "Login successfully";
                var userRole = account.Role;
                Response.Cookies.Append("Role", userRole.ToString());
                Response.Cookies.Append("Username", Username);
                DateTime expirationDate = DateTime.Now.AddSeconds(30);

                CookieOptions options = new CookieOptions
                {
                    Expires = expirationDate
                };
                if (userRole == 1)
                {
                    return Redirect("/admin");
                }
                else
                {

                    return Redirect("/staff");
                }
            }
            else
            {
                TempData["error"] = "Please check username and password";
                return Redirect("/login");
            }
        }
    }
}
