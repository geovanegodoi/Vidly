using System.Collections.Generic;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class RoleDAO : BaseDAO<long, Role, RoleCriteriaTO>, IRoleDAO
    {
        public override IEnumerable<Role> Search(RoleCriteriaTO criteria)
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