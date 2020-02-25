using Microsoft.AspNetCore.Mvc;
using Vidly.Web.Repositories;

namespace Vidly.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Route("customers/Details/{id}")]
        public IActionResult Details(int id)
        {
            var customer = customerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();
            //return NotFound("The movie does not exist in the database.");

            return View(customer);
        }

        [Route("customers")]
        public IActionResult Index()
        {
            var customers = customerRepository.GetAllCustomers();

            return View(customers);
        }
    }
}