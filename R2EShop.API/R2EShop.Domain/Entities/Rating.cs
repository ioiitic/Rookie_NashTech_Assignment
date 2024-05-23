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
    public class Rating : Entity
    {
        public double Score { get; set; }
        public string? Comment { get; set; }
        public bool OrderVerified { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public User? User { get; set; }
        public CaseType? CaseType { get; set; }

        public Rating()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
