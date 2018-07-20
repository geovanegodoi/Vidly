using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Core.Domain;
using Vidly.TO;

namespace Vidly.Core.DAO
{
    public class RentalDAO : BaseDAO<long, Rental, RentalCriteriaTO>, IRentalDAO
    {
        public override Rental Get(long id)
        {
            return this.DBSet
                       .Include(i => i.Customer)
                       .Include(i => i.Movies)
                       .FirstOrDefault(i => i.Id == id);
        }

        public override long Save(Rental domain)
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


        public override IEnumerable<Rental> Search(RentalCriteriaTO criteria)
        {
            var query = this.DBSet
                               .Include(i => i.Customer)
                               .Include(i => i.Movies)
                               .AsQueryable();

            if (criteria != null)
            {
                //if (!String.IsNullOrEmpty(criteria.Name))
                //    retValue = this.DBSet.Where(c => c.Name.Contains(criteria.Name));

                //if (!String.IsNullOrEmpty(criteria.Login))
                //    retValue = this.DBSet.Where(c => c.Login == criteria.Login);

                //if (!String.IsNullOrEmpty(criteria.Password))
                //    retValue = this.DBSet.Where(c => c.Password == criteria.Password);
            }
            return query.ToList();
        }
    }
}