using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF
{
    public interface ICosmosRepository<TEntity> : IRepository<TEntity>
    {
    }
}
