using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactApp.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("name=DbContext")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(c => c.ID);

            base.OnModelCreating(modelBuilder);
        }
    }
}