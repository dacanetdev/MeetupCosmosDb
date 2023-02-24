namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
