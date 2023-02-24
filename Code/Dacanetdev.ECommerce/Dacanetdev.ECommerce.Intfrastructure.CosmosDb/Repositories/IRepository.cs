using System.Linq.Expressions;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);

        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity, string? valueToDelete = null);
    }
}
