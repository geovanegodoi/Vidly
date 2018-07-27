using System.Web.Mvc;
using Vidly.Core.BO;
using Vidly.Interfaces.BO;
using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : BaseController<long, MovieTO, MovieViewModel, MovieCriteriaTO, IMovieBO>
    {
        public MoviesController()
        {
            this.DefaultBO = new MovieBO();
        }
    }
}