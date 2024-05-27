using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class CaseType : Entity
    {
        public string CaseTypeName { get; set; } = string.Empty;
        public int Protection { get; set; } = 0;
        public int Weight { get; set; } = 0;
        public double AverageStar { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<PhoneCase>? PhoneCases { get; set; }

        public CaseType()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
