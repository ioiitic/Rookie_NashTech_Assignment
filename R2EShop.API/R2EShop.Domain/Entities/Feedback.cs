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
    public class Feedback : Entity
    {
        public float Score { get; set; }
        public string? Comment { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
