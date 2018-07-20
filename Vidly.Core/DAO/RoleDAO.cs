using System.Collections.Generic;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class RoleDAO : BaseDAO<long, Role, RoleCriteriaTO>, IRoleDAO
    {
        public override long Save(Role domain)
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