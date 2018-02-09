using Vidly.TO;
<<<<<<< HEAD

namespace Vidly.Interfaces.BO
{
    public interface IMovieBO : IBO<long, MovieTO, MovieCriteriaTO>
=======
using Vidly.ViewModel;

namespace Vidly.Interfaces.BO
{
    public interface IMovieBO : IBO<long, MovieTO, MovieViewModel, MovieCriteriaTO>
>>>>>>> dev
    {

    }
}
