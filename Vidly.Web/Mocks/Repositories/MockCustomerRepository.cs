using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Mocks.Enums;
using Vidly.Web.Models;
using Vidly.Web.Repositories;

namespace Vidly.Web.Mocks.Repositories
{
    public partial class MockCustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int customerId)
        {
            return GetCustomers().SingleOrDefault(m => m.Id == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetCustomers();
        }

        private Customer CreateCustomer(int customerId, string customerFirstName, string customerLastName, MockMemberShipTypes membershipType)
        {
            return new Customer
            {
                Id = customerId,
                FirstName = customerFirstName,
                LastName = customerLastName,
                Birthdate = DateTime.Now,
                MemberShipTypeId = (byte)membershipType.GetHashCode(),
                MembershipType = new MembershipType
                {
                    Id = (byte)membershipType.GetHashCode(),
                    Name = membershipType.ToString()
                }
            };
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                CreateCustomer(1, "Seleni", "Ferrari", MockMemberShipTypes.PayAsYouGo),
                CreateCustomer(2, "Laia", "Aguayo", MockMemberShipTypes.Monthly),
            };
        }
    }
}