using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class MovieDAO : BaseDAO<long, Domain.Movie, TO.MovieCriteriaTO>
    {
        public override IEnumerable<Movie> Search(MovieCriteriaTO criteria)
        {
            var retValue = new List<Movie>();

            if (criteria == null)
            {
                retValue = base.Search(criteria).ToList();
            }
            else if (!String.IsNullOrEmpty(criteria.Name))
            {
                retValue = this.DBSet.Where(c => c.Name.Equals(criteria.Name)).ToList();
            }
            return retValue;
        }
    }
}
