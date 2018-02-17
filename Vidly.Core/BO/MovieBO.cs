using AutoMapper;
using System;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Domain;
using Vidly.Interfaces.BO;
using Vidly.Interfaces.DAO;
using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Core.BO
{
    public class MovieBO : BaseBO<long, MovieTO, MovieViewModel, MovieCriteriaTO, Movie, IMovieDAO>, IMovieBO
    {
        private GenderDAO GenderDAO = null;

        public MovieBO()
        {
            this.DefaultDAO = new MovieDAO();
            this.GenderDAO  = new GenderDAO();
        }

        public MovieViewModel GetViewModel()
        {
            return GetViewModel(0);
        }

        public MovieViewModel GetViewModel(long id)
        {
            var genders = Mapper.Map<IEnumerable<GenderTO>>(this.GenderDAO.ListAll());
            var movie   = (id == 0) ? new MovieTO() : Mapper.Map<MovieTO>(DefaultDAO.Get(id));

            return new ViewModel.MovieViewModel
            {
                Genders = genders,
                Movie   = movie
            };
        }
    }
}
