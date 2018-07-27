using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers.Api
{
    public class RentalsController : BaseApiController<long, RentalTO, RentalCriteriaTO, IRentalBO>
    {
        public RentalsController()
        {
            this.DefaultBO = new RentalBO();
        }
    }
}