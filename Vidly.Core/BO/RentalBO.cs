using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Interfaces.BO;
using Vidly.TO;
using Vidly.ViewModel;
using System;
using Vidly.Core.Domain;

namespace Vidly.Core.BO
{
    public class RentalBO : BaseBO<long, RentalTO, RentalCriteriaTO, Rental, IRentalDAO>, IRentalBO
    {
        private IMovieBO MovieBO = null;

        public RentalBO()
        {
            this.DefaultDAO = new RentalDAO();
            this.MovieBO    = new MovieBO();
        }

        public override RentalTO CreateModelInstance()
        {
            return new RentalTO();
        }

        public override long Save(RentalTO model)
        {
            model.Movies = new List<MovieTO>();

            foreach (var movieId in model.MoviesId)
            {
                model.Movies.Add(MovieBO.Get(movieId));
            }
            return base.Save(model);
        }
    }
}