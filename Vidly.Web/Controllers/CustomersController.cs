using System.Web.Mvc;
using Vidly.Core.BO;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Controllers
{
    public class CustomersController : BaseController<long, CustomerTO, CustomerCriteriaTO>
    {
        public CustomersController()
        {
            this.DefaultBO = new CustomerBO();
        }
    }
}