using AutoMapper;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Interfaces.BO;
using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Core.BO
{
    public class MovieBO : BaseBO<long, MovieTO, MovieViewModel, MovieCriteriaTO, Domain.Movie, IMovieDAO>, IMovieBO
    {
        private IGenderDAO GenderDAO = null;

        public MovieBO()
        {
            this.DefaultDAO = new MovieDAO();
            this.GenderDAO  = new GenderDAO();
        }

        public override MovieViewModel GetViewModel()
        {
            return GetViewModel(0);
        }

        public override MovieViewModel GetViewModel(long id)
        {
            var genders = Mapper.Map<IEnumerable<GenderTO>>(this.GenderDAO.GetAll());
            var movie   = (id == 0) ? new MovieTO() : Mapper.Map<MovieTO>(DefaultDAO.Get(id));

            return new ViewModel.MovieViewModel
            {
                Genders = genders,
                Movie   = movie
            };
        }
    }
}
