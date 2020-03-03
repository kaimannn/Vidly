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
        private List<Customer> _customersList = null;
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public MockCustomerRepository(IMembershipTypeRepository membershipTypeRepository)
        {
            InitializeCustomersList();
            _membershipTypeRepository = membershipTypeRepository;
        }

        private void InitializeCustomersList()
        {
            _customersList = new List<Customer>
            {
                CreateCustomer(1, "Seleni", "Ferrari", MockMemberShipTypes.PayAsYouGo),
                CreateCustomer(2, "Laia", "Aguayo", MockMemberShipTypes.Monthly),
            };
        }

        public Customer GetCustomer(int customerId)
        {
            return _customersList.SingleOrDefault(m => m.Id == customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customersList;
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


        public void AddCustomer(Customer customer)
        {
            customer.Id = GetLastInsertedCustomerId() + 1;

            customer.MembershipType = new MembershipType
            {
                Id = customer.MemberShipTypeId,
                Name = _membershipTypeRepository.GetMembershipType(customer.MemberShipTypeId).Name
            };

            _customersList.Add(customer);
        }

        private int GetLastInsertedCustomerId()
        {
            return _customersList[_customersList.Count - 1].Id;
        }

        public void UpdateCustomer(Customer customer)
        {
            var customerInMemory = _customersList[customer.Id];

            customerInMemory.FirstName = customer.FirstName;
            customerInMemory.LastName = customer.LastName;
            customerInMemory.Birthdate = customer.Birthdate;
            customerInMemory.MemberShipTypeId = customer.MemberShipTypeId;
            customerInMemory.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        }
    }
}