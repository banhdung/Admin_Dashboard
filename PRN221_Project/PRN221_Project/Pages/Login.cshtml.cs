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
        public string ?Username { get; set; }

        [BindProperty]
        public string ?Password { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            AccountService accountService = new AccountService(_context);
            Account account = accountService.getAccountByUserNameAndPassword(Username, Password);
            if (account != null)
            {
				TempData["success"] = "Login successfully";
				if(account.Role == 1)
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
