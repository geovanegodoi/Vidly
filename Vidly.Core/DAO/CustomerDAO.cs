using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{
    public class CustomerDAO : BaseDAO<long, Domain.Customer, TO.CustomerCriteriaTO>, ICustomerDAO
    {
        public override Customer Get(long id)
        {
            return this.DBSet
                       .Include(i => i.MembershipType)
                       //.Include(i => i.Role)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override IEnumerable<Customer> Search(CustomerCriteriaTO criteria)
        {
            var retValue = this.DBSet
                               .Include(i => i.MembershipType)
                               //.Include(i => i.Role)
                               .AsQueryable();

            if (criteria != null)
            {
                if (!String.IsNullOrEmpty(criteria.Name))
                    retValue = this.DBSet.Where(c => c.Name.ToUpper().Contains(criteria.Name.ToUpper()));

                if (!String.IsNullOrEmpty(criteria.Login))
                    retValue = this.DBSet.Where(c => c.Login == criteria.Login);

                if (!String.IsNullOrEmpty(criteria.Password))
                    retValue = this.DBSet.Where(c => c.Password == criteria.Password);
            }
            return retValue.ToList();
        }

        public override IEnumerable<Customer> SearchByName(string name)
        {
            var criteria = new CustomerCriteriaTO { Name = name };
            return this.Search(criteria);
        }
    }
}