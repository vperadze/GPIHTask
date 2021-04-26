using GPIHTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<CompanyOnMarketPrice> CompanyOnMarketPrices { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
