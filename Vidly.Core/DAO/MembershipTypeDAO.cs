using System.Collections.Generic;
using System.Linq;
using Vidly.Domain;
using Vidly.Interfaces.DAO;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class MembershipTypeDAO : BaseDAO<long, Domain.MembershipType, TO.MembershipTypeCriteriaTO>, IMembershipTypeDAO
    {
        public override long Save(MembershipType domain)
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

        public override IEnumerable<MembershipType> Search(MembershipTypeCriteriaTO criteria)
        {
            var retValue = this.DBSet.AsQueryable();

            if (criteria != null)
            {
                if (criteria.SignUpFee > 0)
                    retValue = this.DBSet.Where(c => c.SignUpFee == criteria.SignUpFee);

                if (criteria.DurationInMonths > 0)
                    retValue = this.DBSet.Where(c => c.DurationInMonths == criteria.DurationInMonths);

                if (criteria.DiscountRate > 0)
                    retValue = this.DBSet.Where(c => c.DiscountRate == criteria.DiscountRate);
            }
            return retValue.ToList();
        }
    }
}