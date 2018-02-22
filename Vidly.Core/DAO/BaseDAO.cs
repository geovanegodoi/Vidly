using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Interfaces;

namespace Vidly.Core.DAO
{
    public abstract class BaseDAO<TKey, TDomain, TCriteria> : IDAO<TKey, TDomain, TCriteria> 
        where TDomain   : class
        where TCriteria : class
    {
        protected EntitiesContext Context = new EntitiesContext();
        protected DbSet<TDomain>  DBSet
        {
            get { return this.Context.Set<TDomain>(); }
        }

        public abstract TKey Save(TDomain domain);

        public abstract IEnumerable<TDomain> ListAll();

        public abstract IEnumerable<TDomain> Search(TCriteria criteria);

        public virtual TDomain Get(TKey id)
        {
            return this.Context.Set<TDomain>().Find(id);
        }

        public virtual void Delete(TKey id)
        {
            var entry = this.Get(id);

            if (entry == null)
                throw new KeyNotFoundException("Key not found");

            this.Delete(entry);
        }

        public virtual void Delete(TDomain model)
        {
            var entry = this.Context.Entry(model);
            if (entry.State == EntityState.Detached)
            {
                this.DBSet.Attach(model);
            }
            this.Context.Entry(model).State = EntityState.Deleted;
            this.Context.SaveChanges();
        }
    }
}
