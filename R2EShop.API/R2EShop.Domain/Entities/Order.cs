using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public float? TotalPrice { get; set; }
        public User? OrderUser { get; set; }
        public virtual IList<OrderDetail>? Detail { get; set; }
    }
}
