using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Core.Extensions
{
    public static class DbContextExtension
    {
        public static TEntity GetReference<TEntity, TKey>(this DbContext ctx, TKey key) where TEntity : class
        {
            TEntity result = null;

            PropertyInfo propertyKey = null;
            foreach (var property in typeof(TEntity).GetTypeInfo().GetProperties())
            {
                if (property.GetCustomAttribute<KeyAttribute>() != null)
                {
                    propertyKey = property;
                    break;
                }
            }

            result = ctx.Set<TEntity>().Local.Where(a => propertyKey.GetValue(a).Equals(key)).FirstOrDefault();

            if (propertyKey == null)
                throw new InvalidOperationException("No property Key was found.");

            if (result == null)
            {
                result = Activator.CreateInstance<TEntity>();
                propertyKey.SetValue(result, key);
                ctx.Set<TEntity>().Attach(result);
            }
            return result;
        }
    }
}
