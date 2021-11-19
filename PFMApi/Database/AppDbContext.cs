using Microsoft.EntityFrameworkCore;
using PFMApi.Database.Entity.CategoriesE;
using PFMApi.Database.Entity.TransactionsE;

namespace PFMApi.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Db Set Tables
        public DbSet<Transactions> Transactions { get; set; }

        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
