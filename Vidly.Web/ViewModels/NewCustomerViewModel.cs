using System.Collections.Generic;
using Vidly.Web.Models;

namespace Vidly.Web.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}
