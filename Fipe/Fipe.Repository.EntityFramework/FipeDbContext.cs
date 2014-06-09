using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Fipe.Domain;

namespace Fipe.Repository.EntityFramework
{
    public class FipeDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }

        public FipeDbContext(string connectionString)
            : base(connectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Brand>().HasKey(x => new { x.Id, x.Name });

            base.OnModelCreating(modelBuilder);
        }
    }
}