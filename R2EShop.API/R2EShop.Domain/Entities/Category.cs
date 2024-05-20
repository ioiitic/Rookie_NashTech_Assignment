using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Category : Entity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public virtual ICollection<Product>? Products { get; set; }
    }
}
