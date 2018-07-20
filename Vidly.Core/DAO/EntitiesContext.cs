using System.Data.Entity;
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

            modelBuilder.Entity<Domain.Action>().ToTable("ACTIONS");
            modelBuilder.Entity<Customer>().ToTable("CUSTOMERS");
            modelBuilder.Entity<Form>().ToTable("FORMS");
            modelBuilder.Entity<Gender>().ToTable("GENDERS");
            modelBuilder.Entity<MembershipType>().ToTable("MEMBERSHIPTYPES");
            modelBuilder.Entity<Movie>().ToTable("MOVIES");
            modelBuilder.Entity<Permission>().ToTable("PERMISSIONS");
            modelBuilder.Entity<Role>().ToTable("ROLES");

            base.OnModelCreating(modelBuilder);
        }
    }
}
