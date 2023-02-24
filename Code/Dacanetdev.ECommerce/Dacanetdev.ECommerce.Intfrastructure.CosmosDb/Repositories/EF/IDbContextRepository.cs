using System.Linq.Expressions;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF
{
    public interface IDbContextRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entity, string? valueToDelete = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}