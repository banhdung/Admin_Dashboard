using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using PRN221_Project.Services.IService;

namespace PRN221_Project.Services
{
    public class CustomerService : ICustomerService
    {
        private POSTContext _context;
        public CustomerService(POSTContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer c)
        {
            try
            {
                _context.Customers.Add(c);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            Customer c = _context.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (c != null)
            {
                return c;
            }
            else
            {
                throw (new Exception("Customer with id " + id + " does not exist"));
            }
        }

        public void UpdateCustomer(Customer c)
        {
            throw new NotImplementedException();
        }
    }
}
