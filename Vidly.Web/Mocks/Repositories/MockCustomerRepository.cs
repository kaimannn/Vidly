using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;
using Vidly.Web.Repositories;

namespace Vidly.Web.Mocks.Repositories
{
    public class MockCustomerRepository : ICustomerRepository
    {
        enum MemberShipTypes
        {
            PayAsYouGo = 1,
            Monthly = 2,
            Quarterly = 3,
            Annually = 4
        }

        public Customer GetCustomer(int customerId)
        {
            return GetCustomers().SingleOrDefault(m => m.Id == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetCustomers();
        }

        private Customer CreateCustomer(int customerId, string customerFirstName, string customerLastName, MemberShipTypes membershipType)
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
                CreateCustomer(1, "Seleni", "Ferrari", MemberShipTypes.PayAsYouGo),
                CreateCustomer(2, "Laia", "Aguayo", MemberShipTypes.Monthly),
            };
        }
    }
}