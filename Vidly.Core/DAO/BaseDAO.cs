using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Interfaces;

namespace Vidly.Core.DAO
{
    public abstract class BaseDAO<TKey, TDomain, TCriteria> : IDAO<TKey, TDomain, TCriteria> 
        where TDomain : class
        where TCriteria : class
    {
        protected EntitiesContext Context { get; private set;  }
        protected DbSet<TDomain>  DBSet   { get; private set;  }

        public BaseDAO()
        {
            this.Context = new EntitiesContext();
            this.DBSet   = this.Context.Set<TDomain>();
        }

        public virtual TDomain Get(TKey id)
        {
            return this.Context.Set<TDomain>().Find(id);
        }

        public virtual int Save(TDomain model)
        {
            this.DBSet.Add(model);
            return this.Context.SaveChanges();
        }

        public virtual IEnumerable<TDomain> Search(TCriteria criteria)
        {
            var retList = new List<TDomain>();

            if (criteria is null)
            {
                retList = this.DBSet.ToList();
            }
            return retList;
        }

        public virtual void Delete(TKey id)
        {
            var entry = this.Get(id);
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
