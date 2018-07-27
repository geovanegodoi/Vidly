using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{
    public class PermissionDAO : BaseDAO<long, Permission, PermissionCriteriaTO>, IPermissionDAO
    {
        public override Permission Get(long id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Permission> Search(PermissionCriteriaTO criteria)
        {
            var retValue = this.DBSet
                               .Include(i => i.Action)
                               .Include(i => i.Form)
                               .Include(i => i.Role)
                               .AsQueryable();

            if (criteria != null)
            {
                if (criteria.ActionId > 0)
                    retValue = this.DBSet.Where(c => c.ActionId == criteria.ActionId);

                if (criteria.FormId > 0)
                    retValue = this.DBSet.Where(c => c.FormId == criteria.FormId);

                if (criteria.RoleId > 0)
                    retValue = this.DBSet.Where(c => c.RoleId == criteria.RoleId);
            }
            return retValue.ToList();
        }
    }
}