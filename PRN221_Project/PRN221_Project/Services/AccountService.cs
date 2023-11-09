using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Services
{
    public class AccountService : IAccountService
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
        
        public Account getAccountByUserName(string userName) {
            Account account = _context.Accounts.FirstOrDefault(a => a.Username == userName);
            return account;
        }

        public List<Account> getAccounts()
        {
            return _context.Accounts.ToList();
        }

        public void AddAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
            }catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.AccountId == id);
        }

        public void UpdateAccount(Account account)
        {
            Account a = _context.Accounts.FirstOrDefault(y => y.AccountId == account.AccountId);
            if(a != null)
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
            else
            {
                throw (new Exception("Account with id " + account.AccountId + " does not exist"));
            }
        }
    }
}
