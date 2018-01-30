using Vidly.Core.BO;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Controllers
{
    public class CustomersController : BaseController<long, CustomerTO, CustomerCriteriaTO, Customer>
    {
        public CustomersController()
        {
            this.DefaultBO = new CustomerBO();
        }
    }
}