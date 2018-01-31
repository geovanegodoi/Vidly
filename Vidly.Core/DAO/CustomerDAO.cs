using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{

    public class CustomerDAO : BaseDAO<long, Domain.Customer, TO.CustomerCriteriaTO>
    {
        public override IEnumerable<Customer> Search(CustomerCriteriaTO criteria)
        {
            var retValue = new List<Customer>();

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