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
                       .Include(i => i.Role)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override long Save(Domain.Customer domain)
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
            this.Context.SaveChanges();

            return domain.Id;
        }


        public override IEnumerable<Customer> Search(CustomerCriteriaTO criteria)
        {
            var retValue = this.DBSet
                               .Include(i => i.MembershipType)
                               .Include(i => i.Role)
                               .AsQueryable();

            if (criteria != null)
            {
                if (!String.IsNullOrEmpty(criteria.Name))
                    retValue = this.DBSet.Where(c => c.Name.Contains(criteria.Name));

                if (!String.IsNullOrEmpty(criteria.Login))
                    retValue = this.DBSet.Where(c => c.Login == criteria.Login);

                if (!String.IsNullOrEmpty(criteria.Password))
                    retValue = this.DBSet.Where(c => c.Password == criteria.Password);
            }
            return retValue.ToList();
        }
    }
}