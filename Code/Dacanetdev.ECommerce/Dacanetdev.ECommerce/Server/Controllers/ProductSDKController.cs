using Dacanetdev.ECommerce.Domain;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.SDK.Core;
using Dacanetdev.ECommerce.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Dacanetdev.ECommerce.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSDKController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;

        public ProductSDKController(IProductRepository productRepository, ISaleRepository saleRepository)
        {
            _productRepository = productRepository;
            _productRepository.PartitionKeyDef = "id";
            _saleRepository = saleRepository;
            _saleRepository.PartitionKeyDef = "id";

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepository.GetAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Sale sale)
        {
            await _saleRepository.InsertAsync(sale.ToEntity());

            return Ok(sale);
        }
    }
}
