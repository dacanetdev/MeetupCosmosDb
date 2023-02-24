using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToContainer("product")
                .HasNoDiscriminator()
                .HasPartitionKey(_ => _.Id);

            builder.MapProperties();
        }
    }
}
