namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities
{
    public class Sale: Entity
    {
        public Guid CustomerId { get; set; }
        public double Total { get; set; } = 0;

        public List<SaleItem>? SaleItems { get; set; }
    }
}
