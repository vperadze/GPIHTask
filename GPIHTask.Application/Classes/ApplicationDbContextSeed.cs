using GPIHTask.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GPIHTask.Application.Classes
{
    public class ApplicationDbContextSeed
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                  new ApplicationUser
                  {
                      Id = 1,
                      UserName = "admin",
                      FullName = "Vakhtang Peradze",
                      PasswordHash = hasher.HashPassword(null, "admin")
                  });

            modelBuilder.Entity<Company>().HasData(
               new Company { Id = 1, Title = "Apple", LogoPath = "../assets/images/apple.png", Description = "" },
                    new Company { Id = 2, Title = "Microsoft", LogoPath = "../assets/images/Microsoft.png", Description = "" },
                    new Company { Id = 3, Title = "Google", LogoPath = "../assets/images/Google.png", Description = "" },
                    new Company { Id = 4, Title = "GPIH", LogoPath = "../assets/images/GPIH.png", Description = "" },
                    new Company { Id = 5, Title = "Ford", LogoPath = "../assets/images/Ford.png", Description = "" });

            modelBuilder.Entity<Market>().HasData(
               new Market { Id = 1, Title = "Market 1", Description = "" },
                    new Market { Id = 2, Title = "Market 2", Description = "" },
                    new Market { Id = 3, Title = "Market 3", Description = "" });

            modelBuilder.Entity<CompanyOnMarketPrice>().HasData(
              new CompanyOnMarketPrice { Id = 1, CompanyId = 1, MarketId = 1, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 2, CompanyId = 2, MarketId = 1, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 3, CompanyId = 3, MarketId = 1, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 4, CompanyId = 4, MarketId = 1, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 5, CompanyId = 5, MarketId = 1, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 6, CompanyId = 1, MarketId = 2, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 7, CompanyId = 2, MarketId = 2, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 8, CompanyId = 3, MarketId = 2, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 9, CompanyId = 4, MarketId = 2, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 10, CompanyId = 5, MarketId = 2, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 11, CompanyId = 1, MarketId = 3, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 12, CompanyId = 2, MarketId = 3, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 13, CompanyId = 3, MarketId = 3, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 14, CompanyId = 4, MarketId = 3, Price = 0.0m },
                   new CompanyOnMarketPrice { Id = 15, CompanyId = 5, MarketId = 3, Price = 0.0m });
        }
    }
}
