using GPIHTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPIHTask.Domain.Configurations
{
    public class CompanyOnMarketPriceConfiguration : IEntityTypeConfiguration<CompanyOnMarketPrice>
    {
        public void Configure(EntityTypeBuilder<CompanyOnMarketPrice> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
