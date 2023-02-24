using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF.Core
{
    public interface IProductRepository: ICosmosRepository<Product>
    {
    }
}
