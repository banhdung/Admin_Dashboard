using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Pages.Admin.Employee
{
    public class IndexModel : PageModel
    {
        private IAccountService accountService;

        public IndexModel(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IList<Account> Account { get;set; } = default!;

        public async Task OnGetAsync()
        {
           if(accountService.getAccounts() != null)
            {
                Account = accountService.getAccounts();
            }

        }
    }
}
