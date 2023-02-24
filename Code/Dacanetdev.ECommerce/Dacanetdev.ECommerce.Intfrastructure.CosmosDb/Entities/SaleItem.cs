namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities
{
    public class SaleItem: Entity
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; } = 0;
    }
}
