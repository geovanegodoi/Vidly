using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class GenderDAO : BaseDAO<long, Domain.Gender, TO.GenderCriteriaTO>
    {
        public override int Save(Gender domain)
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

        public override IEnumerable<Gender> ListAll()
        {
            return this.Search(new GenderCriteriaTO());
        }

        public override IEnumerable<Gender> Search(GenderCriteriaTO criteria)
        {
            var retValue = this.DBSet.AsQueryable();

            if (!string.IsNullOrEmpty(criteria.Name))
                retValue = this.DBSet.Where(c => c.Name == criteria.Name);

            return retValue.ToList();
        }
    }
}