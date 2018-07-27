using System.Data.Entity;
using Vidly.Core.Domain;

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

            modelBuilder.Entity<Action>().ToTable("ACTIONS");
            modelBuilder.Entity<Customer>().ToTable("CUSTOMERS");
            modelBuilder.Entity<Form>().ToTable("FORMS");
            modelBuilder.Entity<Gender>().ToTable("GENDERS");
            modelBuilder.Entity<MembershipType>().ToTable("MEMBERSHIPTYPES");
            modelBuilder.Entity<Movie>().ToTable("MOVIES");
            modelBuilder.Entity<Permission>().ToTable("PERMISSIONS");
            modelBuilder.Entity<Role>().ToTable("ROLES");
            modelBuilder.Entity<Rental>().ToTable("RENTALS");

            modelBuilder.Entity<Rental>()
                        .HasMany(s => s.Movies)
                        .WithMany(c => c.Rentals)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("RENTALID");
                            cs.MapRightKey("MOVIEID");
                            cs.ToTable("RENTALSMOVIES");
                        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
