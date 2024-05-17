using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Product : Entity
    {
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double ProductPrice { get; set; } = 0;
        public string PhotoUrl { get; set; } = string.Empty;
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; } 
    }
}
