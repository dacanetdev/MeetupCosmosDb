using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Configuration;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.EF;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.SDK;
using EFRepos = Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF;
using SDKRepos = Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK;

namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions
{
    public static class CosmosModule
    {
        public static void AddCosmosModules(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosConfiguration = configuration.GetSection("CosmosDb").Get<CosmosConfiguration>();

            services.AddDbContext<ECommerceDbContext>(options =>
               options.UseCosmos(cosmosConfiguration.Account, cosmosConfiguration.Key, databaseName: cosmosConfiguration.DatabaseName, (options) =>
               {
                   options.ConnectionMode(ConnectionMode.Gateway);
               }));

            services.AddSingleton(cosmosConfiguration);
            services.AddSingleton<ICosmosDbProvider, CosmosDbProvider>();

            services.AddScoped<EFRepos.Core.IProductRepository, EFRepos.ProductRepository>();
            services.AddScoped<EFRepos.Core.ISaleRepository, EFRepos.SaleRepository>();
            services.AddScoped<SDKRepos.Core.IProductRepository, SDKRepos.ProductRepository>();
            services.AddScoped<SDKRepos.Core.ISaleRepository, SDKRepos.SaleRepository>();
        }
    }
}
