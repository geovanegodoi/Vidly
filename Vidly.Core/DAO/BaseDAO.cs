using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Vidly.Core.Extensions;

namespace Vidly.Core.DAO
{
    public abstract class BaseDAO<TKey, TDomain, TCriteria> : BaseEntityContextDAO<EntitiesContext>, IDAO<TKey, TDomain, TCriteria>
        where TDomain : class
        where TCriteria : class
    {
        protected DbSet<TDomain> DBSet
        {
            get { return this.Context.Set<TDomain>(); }
        }

        public virtual TKey Save(TDomain domain)
        {
            PropertyInfo propertyKey = null;
            foreach (var property in typeof(TDomain).GetTypeInfo().GetProperties())
            {
                if (property.GetCustomAttribute<KeyAttribute>() != null)
                {
                    propertyKey = property;
                    break;
                }
            }
            if (propertyKey == null)
                throw new InvalidOperationException("No property Key was found.");

            var entity = this.Get((TKey)propertyKey.GetValue(domain));

            if (entity == null)
            {
                this.DBSet.Add(domain);
            }
            else
            {
                this.Context.Entry(entity).CurrentValues.SetValues(domain);
            }
            this.Context.SaveChanges();

            return (TKey)propertyKey.GetValue(domain);
        }

        public abstract IEnumerable<TDomain> Search(TCriteria criteria);

        public virtual IEnumerable<TDomain> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual TDomain Get(TKey id)
        {
            return this.Context.Set<TDomain>().Find(id);
        }

        public TDomain GetReference(TKey id)
        {
            return Context.GetReference<TDomain, TKey>(id);
        }

        public virtual IEnumerable<TDomain> GetAll()
        {
            return this.Search(null);
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
