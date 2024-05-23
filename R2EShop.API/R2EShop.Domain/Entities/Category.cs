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
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<PhoneCase>? Products { get; set; }
    }
}
