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
        public string Username { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public Address? Address { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
