using System.Collections.Generic;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class GenderDAO : BaseDAO<long, Gender, GenderCriteriaTO>, IGenderDAO
    {
        public override IEnumerable<Gender> Search(GenderCriteriaTO criteria)
        {
            var retValue = this.DBSet.AsQueryable();

            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.Name))
                    retValue = this.DBSet.Where(c => c.Name == criteria.Name);
            }
            return retValue.ToList();
        }
    }
}