using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Configuration
{
    internal class SaleConfiguration: IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .ToContainer("sale")
                .HasNoDiscriminator()
                .HasPartitionKey(_ => _.Id);

            builder.MapProperties();

            builder.OwnsMany(_ => _.SaleItems, si =>
            {
                si.MapProperties();
            });
        }
    }
}
