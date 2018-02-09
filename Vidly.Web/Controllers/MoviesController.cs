using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;
<<<<<<< HEAD

namespace Vidly.Controllers
{
    public class MoviesController : BaseController<long, MovieTO, MovieCriteriaTO, IMovieBO>
=======
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : BaseController<long, MovieTO, MovieViewModel, MovieCriteriaTO, IMovieBO>
>>>>>>> dev
    {
        public MoviesController()
        {
            this.DefaultBO = new MovieBO();
        }
    }
}