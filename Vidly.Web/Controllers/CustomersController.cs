using Microsoft.AspNetCore.Mvc;
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

            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [Route("customers")]
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers();

            return View(customers);
        }
    }
}