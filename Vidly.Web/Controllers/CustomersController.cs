using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : BaseController<long, CustomerTO, CustomerViewModel, CustomerCriteriaTO, ICustomerBO>
    {
        public CustomersController()
        {
            this.DefaultBO = new CustomerBO();
        }
    }
}