using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dacanetdev.ECommerce.Domain
{
    public class Sale
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Customer Customer { get; set; }
        public double Total { get; set; } = 0;

        public List<SaleItem>? SaleItems { get; set; } = new List<SaleItem>();
    }
}
