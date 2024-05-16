using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Product : Entity
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double? ProductPrice { get; set; }
        public string? PhotoUrl { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; } 
    }
}
