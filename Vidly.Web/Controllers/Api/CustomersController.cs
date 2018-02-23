using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers.Api
{
    public class CustomersController : BaseApiController<long, CustomerTO, CustomerCriteriaTO, ICustomerBO>
    {
        public CustomersController()
        {
            this.DefaultBO = new CustomerBO();
        }
    }
}
