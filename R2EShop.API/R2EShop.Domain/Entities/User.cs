using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class User : Entity
    {
        public string? Fullname { get; set; }
        public string? EmailAddress { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
