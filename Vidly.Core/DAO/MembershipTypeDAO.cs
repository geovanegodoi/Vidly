using System.Collections.Generic;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class MembershipTypeDAO : BaseDAO<long, MembershipType, MembershipTypeCriteriaTO>, IMembershipTypeDAO
    {
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