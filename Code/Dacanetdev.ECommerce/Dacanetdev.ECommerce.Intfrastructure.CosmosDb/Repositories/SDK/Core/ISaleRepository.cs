using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK.Core
{
    public interface ISaleRepository: ICosmosRepository<Sale>
    {
    }
}
