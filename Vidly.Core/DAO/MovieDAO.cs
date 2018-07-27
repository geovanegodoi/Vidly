using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class MovieDAO : BaseDAO<long, Movie, MovieCriteriaTO>, IMovieDAO
    {
        public override Movie Get(long id)
        {
            return this.DBSet.Include(i => i.Gender)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override IEnumerable<Movie> Search(MovieCriteriaTO criteria)
        {
            var retValue = this.DBSet.Include(i => i.Gender).AsQueryable();

            if (criteria != null)
            {
                if (!String.IsNullOrEmpty(criteria.Name))
                    retValue = this.DBSet.Where(c => c.Name.ToUpper().Contains(criteria.Name.ToUpper()));
            }
            return retValue.ToList();
        }

        public override IEnumerable<Movie> SearchByName(string name)
        {
            var criteria = new MovieCriteriaTO { Name = name };
            return this.Search(criteria);
        }
    }
}
