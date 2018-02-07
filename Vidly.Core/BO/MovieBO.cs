using System;
using Vidly.Core.DAO;
using Vidly.Domain;
using Vidly.Interfaces.BO;
using Vidly.Interfaces.DAO;
using Vidly.TO;

namespace Vidly.Core.BO
{
    public class MovieBO : BaseBO<long, MovieTO, MovieTO, MovieCriteriaTO, Movie, IMovieDAO>, IMovieBO
    {
        public MovieBO()
        {
            this.DefaultDAO = new MovieDAO();
        }
    }
}
