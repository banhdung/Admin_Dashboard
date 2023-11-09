using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Models;
using PRN221_Project.Services;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Admin
{
    public class LoginModel : PageModel
    {


        private IAccountService accountService; 
        public LoginModel(IAccountService accountService)
        {
          this.accountService = accountService;
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
            Account account = accountService.getAccountByUserNameAndPassword(Username, Password);
            if (account != null)
            {
                TempData["success"] = "Login successfully";
                var userRole = account.Role;
                Response.Cookies.Append("Role", userRole.ToString());
                Response.Cookies.Append("Username", account.Fullname);
               
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
