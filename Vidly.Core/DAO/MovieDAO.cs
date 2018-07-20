using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Domain;
using Vidly.Interfaces.DAO;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class MovieDAO : BaseDAO<long, Domain.Movie, TO.MovieCriteriaTO>, IMovieDAO
    {
        public override Movie Get(long id)
        {
            return this.DBSet.Include(i => i.Gender)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override long Save(Domain.Movie domain)
        {
            if (domain.Id == 0)
            {
                this.DBSet.Add(domain);
            }
            else
            {
                var entity = this.Get(domain.Id);
                this.Context.Entry(entity).CurrentValues.SetValues(domain);
            }
            return this.Context.SaveChanges();
        }

        public override IEnumerable<Movie> Search(MovieCriteriaTO criteria)
        {
            var retValue = this.DBSet.Include(i => i.Gender).AsQueryable();

            if (criteria != null)
            {
                if (!String.IsNullOrEmpty(criteria.Name))
                    retValue = this.DBSet.Where(c => c.Name == criteria.Name);
            }
            return retValue.ToList();
        }
    }
}
