using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class OrderItem : Entity
    {
        public float ItemPrice { get; set; }
        public virtual Order? Order { get; set; }
        public virtual PhoneCase? PhoneCase { get; set; }
    }
}
