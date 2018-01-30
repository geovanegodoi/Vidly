using System;
using Vidly.Core.DAO;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Core.BO
{
    public class MovieBO : BaseBO<long, MovieTO, MovieCriteriaTO, Movie>
    {
        public MovieBO()
        {
            this.DefaultDAO = new MovieDAO();
        }
    }
}
