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
        private IMovieDAO MovieDAO = null;

        public RentalBO()
        {
            this.DefaultDAO = new RentalDAO();
            this.MovieDAO   = new MovieDAO();
        }

        public override long Save(RentalTO model)
        {
            Domain.Rental domain = null;

            if (model.Id != 0)
                domain = DefaultDAO.Get(model.Id);
            else
                domain = new Domain.Rental();

            Mapper.Map(model, domain);

            foreach(var item in domain.Movies.Where(a => model.MoviesId == null || !model.MoviesId.Contains(a.Id)).ToList())
            {
                domain.Movies.Remove(item);
            }

            if (model.MoviesId != null)
            {
                foreach (var item in model.MoviesId.Except(domain.Movies.Select(a => a.Id)).ToList())
                {
                    domain.Movies.Add(MovieDAO.GetReference(item));
                }
            }
            return DefaultDAO.Save(domain);
        }
    }
}