using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToContainer("customer")
                .HasNoDiscriminator()
                .HasPartitionKey(_ => _.Id);

            builder.MapProperties();
        }
    }
}
