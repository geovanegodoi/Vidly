using System.Web.Mvc;
using Vidly.Core.BO;
using Vidly.Domain;
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

        [HttpGet]
        public override ActionResult New()
        {
            var viewModel = this.DefaultBO.NewCustomerViewModel();
            return View("Save", viewModel);
        }
    }
}