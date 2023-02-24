using Dacanetdev.ECommerce.Infrastructure.CosmosDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF
{
    public abstract class CosmosRepository<TEntity> : DbContextRepository<ECommerceDbContext, TEntity>, 
        ICosmosRepository<TEntity>
        where TEntity : class
    {
        protected CosmosRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
