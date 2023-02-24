using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF
{
    public abstract class DbContextRepository<TDbContext, TEntity> : IRepository<TEntity>, IDbContextRepository<TEntity> where TEntity : class
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public DbContextRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties)
        {
            var query = DbSet.AsNoTracking();
            if (includeProperties != null && includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));
            }

            return await (predicate == null ? query.ToListAsync() : query.Where(predicate).ToListAsync());
        }

        public virtual async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties)
        {
            var query = DbSet.AsNoTracking();
            if (includeProperties != null && includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));
            }

            return await (predicate == null ? query.FirstOrDefaultAsync() : query.FirstOrDefaultAsync(predicate));
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(TEntity).Name);

            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(TEntity).Name);

            await Task.Run(() =>
            {
                DbSet.Update(entity);
            });

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity, string? valueToDelete = null)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(TEntity).Name);

            await Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
