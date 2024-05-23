using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class CaseColor : Entity
    {
        public string CaseColorName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public CaseColor()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
