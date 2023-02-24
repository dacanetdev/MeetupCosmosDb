using Newtonsoft.Json;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities
{
    public abstract class Entity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
