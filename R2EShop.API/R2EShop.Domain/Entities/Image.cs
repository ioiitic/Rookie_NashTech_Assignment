using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Image : Entity
    {
        public string Url { get; set; } = string.Empty;
        public Guid PhoneCaseId { get; set; }
    }
}
