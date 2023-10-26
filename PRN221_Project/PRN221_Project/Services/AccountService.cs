using PRN221_Project.Models;

namespace PRN221_Project.Services
{
    public class AccountService
    {
        private readonly POSTContext _context;
        public AccountService(POSTContext context)
        {
            _context = context;
        }
        public Account getAccountByUserNameAndPassword(string userName, string password)
        {
            Account account = _context.Accounts.FirstOrDefault(a => a.Username == userName && a.Password == password);
            return account;
        }
    }
}
