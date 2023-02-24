using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Configuration;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.SDK
{
    public class CosmosDbProvider : ICosmosDbProvider
    {
        private readonly CosmosClient _cosmosClient;
        private readonly CosmosConfiguration _cosmosConfiguration;

        public CosmosDbProvider(CosmosConfiguration cosmosConfiguration)
        {
            _cosmosConfiguration = cosmosConfiguration;
            _cosmosClient = new CosmosClient(cosmosConfiguration.Account, cosmosConfiguration.Key, new CosmosClientOptions()
            {
                ConnectionMode = ConnectionMode.Gateway
            });
        }

        public async Task<Container> GetContainerAsync(string containerName, string partitionKeyPath, CancellationToken cancellationToken = default)
        {
            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosConfiguration.DatabaseName, cancellationToken: cancellationToken);

            var container = await database.Database.CreateContainerIfNotExistsAsync(containerName, partitionKeyPath, cancellationToken: cancellationToken);

            return container;
        }

        public async Task CreateContainerAsync(string containerName, string partitionKeyPath, int throughput, CancellationToken cancellationToken = default)
        {
            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_cosmosConfiguration.DatabaseName, cancellationToken: cancellationToken);

            await database.Database.CreateContainerIfNotExistsAsync(containerName, partitionKeyPath, throughput: throughput, cancellationToken: cancellationToken);
        }
    }
}
