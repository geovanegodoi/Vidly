using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers
{
    public class RentalsController : BaseController<long, RentalTO, RentalCriteriaTO, IRentalBO>
    {
        public RentalsController()
        {
            this.DefaultBO = new RentalBO();
        }
    }
}