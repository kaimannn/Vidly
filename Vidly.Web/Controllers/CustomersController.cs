using Microsoft.AspNetCore.Mvc;
using Vidly.Web.Models;
using Vidly.Web.Repositories;
using Vidly.Web.ViewModels;

namespace Vidly.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMembershipTypeRepository _membershipTypeRepository;

        public CustomersController(ICustomerRepository customerRepository, IMembershipTypeRepository membershipTypeRepository)
        {
            _customerRepository = customerRepository;
            _membershipTypeRepository = membershipTypeRepository;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers();

            return View(customers);
        }

        [Route("customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();
            //return NotFound("The movie does not exist in the database.");

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _membershipTypeRepository.GetAllMembershipTypes();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _membershipTypeRepository.GetAllMembershipTypes()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _customerRepository.AddCustomer(customer);
            else
                _customerRepository.UpdateCustomer(customer);

            return RedirectToAction("Index", "Customers");
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _membershipTypeRepository.GetAllMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }
    }
}