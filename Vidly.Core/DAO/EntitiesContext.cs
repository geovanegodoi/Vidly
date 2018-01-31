using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Domain;

namespace Vidly.Core.DAO
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("VidlyDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VIDLY");

            modelBuilder.Entity<Customer>().ToTable("CUSTOMERS");

            modelBuilder.Entity<Movie>().ToTable("MOVIES");

            base.OnModelCreating(modelBuilder);
        }
    }
}
