using Microsoft.Azure.Cosmos;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.SDK
{
    public interface ICosmosDbProvider
    {
        Task CreateContainerAsync(string containerName, string partitionKeyPath, int throughput, CancellationToken cancellationToken = default);
        Task<Container> GetContainerAsync(string containerName, string partitionKeyPath, CancellationToken cancellationToken = default);
    }
}