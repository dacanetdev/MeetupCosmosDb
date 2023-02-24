using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void MapProperties<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class
        {
            var type = typeof(TEntity);
            SetProperties(builder, type);
        }

        public static void MapProperties<TOwnerEntity, IDependentEntity>(this OwnedNavigationBuilder<TOwnerEntity, IDependentEntity> builder)
            where TOwnerEntity : class
            where IDependentEntity : class
        {
            var type = typeof(IDependentEntity);
            foreach (var property in type.GetProperties())
            {
                // excluding class properties since those should be set separately
                if (!(property.PropertyType.IsPrimitive ||
                    property.PropertyType.IsEnum ||
                    property.PropertyType == typeof(bool) ||
                    property.PropertyType == typeof(string) ||
                    property.PropertyType == typeof(decimal) ||
                    property.PropertyType == typeof(char) ||
                    property.PropertyType == typeof(DateTime) ||
                    property.PropertyType == typeof(DateTimeOffset) ||
                    property.PropertyType == typeof(TimeSpan) ||
                    property.PropertyType == typeof(Guid) ||
                    property.PropertyType == typeof(bool?) ||
                    property.PropertyType == typeof(decimal?) ||
                    property.PropertyType == typeof(char?) ||
                    property.PropertyType == typeof(DateTime?) ||
                    property.PropertyType == typeof(DateTimeOffset?) ||
                    property.PropertyType == typeof(TimeSpan?) ||
                    property.PropertyType == typeof(Guid?)))
                    continue;

                builder.Property(property.Name).ToJsonProperty(property.Name.ToCamelCaseString());
            }
        }

        private static void SetProperties<TEntity>(EntityTypeBuilder<TEntity> builder, Type type)
            where TEntity : class
        {
            foreach (var property in type.GetProperties())
            {
                // excluding class properties since those should be set separately
                if (!(property.PropertyType.IsPrimitive ||
                    property.PropertyType.IsEnum ||
                    property.PropertyType == typeof(bool) ||
                    property.PropertyType == typeof(string) ||
                    property.PropertyType == typeof(decimal) ||
                    property.PropertyType == typeof(double) ||
                    property.PropertyType == typeof(int) ||
                    property.PropertyType == typeof(char) ||
                    property.PropertyType == typeof(DateTime) ||
                    property.PropertyType == typeof(DateTimeOffset) ||
                    property.PropertyType == typeof(TimeSpan) ||
                    property.PropertyType == typeof(Guid) ||
                    property.PropertyType == typeof(bool?) ||
                    property.PropertyType == typeof(decimal?) ||
                    property.PropertyType == typeof(double?) ||
                    property.PropertyType == typeof(int?) ||
                    property.PropertyType == typeof(char?) ||
                    property.PropertyType == typeof(DateTime?) ||
                    property.PropertyType == typeof(DateTimeOffset?) ||
                    property.PropertyType == typeof(TimeSpan?) ||
                    property.PropertyType == typeof(Guid?)))
                    continue;

                builder.Property(property.Name).ToJsonProperty(property.Name.ToCamelCaseString());
            }
        }
    }
}
