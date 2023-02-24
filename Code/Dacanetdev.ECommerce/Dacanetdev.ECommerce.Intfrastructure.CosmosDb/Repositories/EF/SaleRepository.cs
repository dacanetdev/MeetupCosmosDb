using Dacanetdev.ECommerce.Infrastructure.CosmosDb.EF;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF.Core;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF
{
    public class SaleRepository : CosmosRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
