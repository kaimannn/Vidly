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
    }
}