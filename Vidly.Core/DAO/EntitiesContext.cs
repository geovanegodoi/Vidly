using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Core.DAO
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("connectionstring")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VIDLY");

            base.OnModelCreating(modelBuilder);
        }
    }
}
