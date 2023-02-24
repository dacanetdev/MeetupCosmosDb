using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Domain
{
    public class SaleItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Product Product { get; set; } = new Product();
        public double Quantity { get; set; } = 0;
    }
}
