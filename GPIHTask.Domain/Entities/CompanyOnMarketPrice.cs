namespace GPIHTask.Domain.Entities
{
    public class CompanyOnMarketPrice
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }
        public decimal Price { get; set; }
    }
}
