using Microsoft.Azure.Cosmos;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using System.Linq.Expressions;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.SDK;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK
{
    public abstract class CosmosRepository<TEntity> : IRepository<TEntity>, ICosmosRepository<TEntity> where TEntity : Entity
    {
        private readonly ICosmosDbProvider _cosmosDbProvider;
        private readonly string _containerName;
        public virtual string GenerateId(TEntity entity) => Guid.NewGuid().ToString();
        public string PartitionKeyDef { get; set; }

        public CosmosRepository(ICosmosDbProvider cosmosDbProvider, string containerName)
        {
            _cosmosDbProvider = cosmosDbProvider;
            _containerName = containerName;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties)
        {
            var container = await _cosmosDbProvider.GetContainerAsync(_containerName, $"/{PartitionKeyDef}").ConfigureAwait(false);

            var response = predicate != null ? container.GetItemLinqQueryable<TEntity>(allowSynchronousQueryExecution: true).Where(predicate) : container.GetItemLinqQueryable<TEntity>(allowSynchronousQueryExecution: true);

            return response.ToList();
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null, params string[] includeProperties)
        {
            var container = await _cosmosDbProvider.GetContainerAsync(_containerName, $"/{PartitionKeyDef}").ConfigureAwait(false);

            var result = predicate != null ? container.GetItemLinqQueryable<TEntity>(allowSynchronousQueryExecution: true).FirstOrDefault(predicate) : container.GetItemLinqQueryable<TEntity>(allowSynchronousQueryExecution: true).FirstOrDefault();

            return result;
        }

        public async Task InsertAsync(TEntity entity)
        {
            var container = await _cosmosDbProvider.GetContainerAsync(_containerName, $"/{PartitionKeyDef}").ConfigureAwait(false);

            await container.CreateItemAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var container = await _cosmosDbProvider.GetContainerAsync(_containerName, $"/{PartitionKeyDef}").ConfigureAwait(false);

            await container.UpsertItemAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity, string? partitionKeyValue = null)
        {
            var container = await _cosmosDbProvider.GetContainerAsync(_containerName, $"/{PartitionKeyDef}").ConfigureAwait(false);

            await container.DeleteItemAsync<TEntity>(entity.Id.ToString(), new PartitionKey(partitionKeyValue));
        }
    }
}
