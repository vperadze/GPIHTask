using GPIHTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPIHTask.Domain.Configurations
{
    public class MarketConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
