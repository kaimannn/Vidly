using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;

namespace Vidly.Web.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
    }

    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLCustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();

        }
    }
}