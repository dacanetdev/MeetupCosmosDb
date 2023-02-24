using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using System.Linq.Expressions;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK
{
    public interface ICosmosRepository<TEntity> where TEntity : Entity
    {
        string PartitionKeyDef { get; set; }

        Task DeleteAsync(TEntity entity, string? partitionKeyValue = null);
        string GenerateId(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}