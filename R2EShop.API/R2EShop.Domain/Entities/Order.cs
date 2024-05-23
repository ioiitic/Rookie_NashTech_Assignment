using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Order : Entity
    {
        public float TotalPrice { get; set; }
        public DateTime CreatedAt { get; private set; }
        public Guid UserId { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public Order()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
