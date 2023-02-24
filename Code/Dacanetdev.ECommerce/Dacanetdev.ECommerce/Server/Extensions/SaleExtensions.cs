using Entities = Dacanetdev.ECommerce.Infrastructure.CosmosDb.Entities;
using Domain = Dacanetdev.ECommerce.Domain;

namespace Dacanetdev.ECommerce.Server.Extensions
{
    public static class SaleExtensions
    {
        public static Entities.Sale ToEntity(this Domain.Sale sale)
        {
            var entity = new Entities.Sale();
            entity.Id = sale.Id;
            entity.CustomerId = sale.Customer.Id;
            entity.Total = sale.Total;
            entity.CreatedBy = $"{sale.Customer.FirstName} {sale.Customer.LastName}";
            entity.CreatedDate = DateTime.Now;
            entity.SaleItems = new List<Entities.SaleItem>();

            foreach (var saleItem in sale.SaleItems)
            {
                entity.SaleItems.Add(new Entities.SaleItem()
                {
                    Id = saleItem.Id,
                    ProductId = saleItem.Product.Id,
                    CreatedBy = $"{sale.Customer.FirstName} {sale.Customer.LastName}",
                    CreatedDate = DateTime.Now
                });
            }

            return entity;
        }
    }
}
