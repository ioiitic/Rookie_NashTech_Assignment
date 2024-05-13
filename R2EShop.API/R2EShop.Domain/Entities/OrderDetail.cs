using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public float? Price { get; set; }
        public virtual Product? Product { get; set; }
    }
}
