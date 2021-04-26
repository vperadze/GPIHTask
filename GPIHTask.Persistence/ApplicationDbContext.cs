using GPIHTask.Application.Classes;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GPIHTask.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<CompanyOnMarketPrice> CompanyOnMarketPrices { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var applicationDbContextSeed = new ApplicationDbContextSeed();
            applicationDbContextSeed.SeedDatabase(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
