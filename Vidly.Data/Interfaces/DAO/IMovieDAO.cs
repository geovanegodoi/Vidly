using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Interfaces.DAO
{
    public interface IMovieDAO : IDAO<long, Movie, MovieCriteriaTO>
    {

    }
}
