using PRN221_Project.Models;

namespace PRN221_Project.Services.IService
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomer();
        public Customer GetCustomerById(int id);
        public void AddCustomer(Customer c);
        public void UpdateCustomer(Customer c);
    }
}
