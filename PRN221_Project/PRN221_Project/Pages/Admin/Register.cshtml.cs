using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Project.Pages.Admin
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
            // Hành động khi nhận GET request
        }

        public IActionResult OnPost()
        {
            // Hành động khi nhận POST request
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Mật khẩu xác nhận không trùng khớp.");
                return Page();
            }

            // Xử lý logic đăng ký tài khoản ở đây

            return RedirectToPage("/Index"); // Chuyển hướng sau khi đăng ký thành công
        }
    }
}
