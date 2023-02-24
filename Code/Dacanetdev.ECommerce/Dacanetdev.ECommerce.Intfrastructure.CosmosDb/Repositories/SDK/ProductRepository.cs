using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK.Core;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK
{
    public class ProductRepository : CosmosRepository<Product>, IProductRepository
    {
        public ProductRepository(ICosmosDbProvider cosmosDbProvider) : base(cosmosDbProvider, "product")
        {
        }
    }
}
