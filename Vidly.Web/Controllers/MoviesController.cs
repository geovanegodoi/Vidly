using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers
{
    public class MoviesController : BaseController<long, MovieTO, MovieCriteriaTO, IMovieBO>
    {
        public MoviesController()
        {
            this.DefaultBO = new MovieBO();
        }
    }
}