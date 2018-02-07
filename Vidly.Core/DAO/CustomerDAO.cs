using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Vidly.Domain;
using Vidly.TO;
using Vidly.Interfaces.DAO;

namespace Vidly.Core.DAO
{
    public class CustomerDAO : BaseDAO<long, Domain.Customer, TO.CustomerCriteriaTO>, ICustomerDAO
    {
        public override Customer Get(long id)
        {
            return this.DBSet.Include(i => i.MembershipType)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override int Save(Domain.Customer domain)
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

        public override IEnumerable<Customer> ListAll()
        {
            return this.Search(new CustomerCriteriaTO());
        }

        public override IEnumerable<Customer> Search(CustomerCriteriaTO criteria)
        {
            var retValue = this.DBSet.Include(i => i.MembershipType).AsQueryable();

            if (!String.IsNullOrEmpty(criteria.Name))
                retValue = this.DBSet.Where(c => c.Name == criteria.Name);

            return retValue.ToList();
        }
    }
}