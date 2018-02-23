using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;

namespace Vidly.Controllers.Api
{
    public class MoviesController : BaseApiController<long, MovieTO, MovieCriteriaTO, IMovieBO>
    {
        public MoviesController()
        {
            this.DefaultBO = new MovieBO();
        }
    }
}