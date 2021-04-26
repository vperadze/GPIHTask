
namespace GPIHTask.Domain.Dtos
{
    public class CompanyOnMarketPriceDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyTitle { get; set; }
        public int MarketId { get; set; }
        public string MarketTitle { get; set; }
        public decimal Price { get; set; }
    }
}
