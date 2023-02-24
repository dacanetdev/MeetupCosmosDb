using Dacanetdev.ECommerce.Domain;
using Dacanetdev.ECommerce.Infrastructure.CosmosDb.Repositories.EF.Core;
using Dacanetdev.ECommerce.Server.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Dacanetdev.ECommerce.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductEFController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ISaleRepository _saleRepository;

        public ProductEFController(IProductRepository productRepository, ISaleRepository saleRepository)
        {
            _productRepository = productRepository;
            _saleRepository = saleRepository;   
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
