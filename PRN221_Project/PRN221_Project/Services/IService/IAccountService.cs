using PRN221_Project.Models;

namespace PRN221_Project.Services.IService
{
    public interface IAccountService 
    {
        public Account getAccountByUserNameAndPassword(string userName, string password);
        public Account getAccountByUserName(string userName);

        public List<Account> getAccounts(); 

        public void AddAccount(Account account);

        public Account GetAccountById(int id);

        public void UpdateAccount(Account account);     
    }
}
