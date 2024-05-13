using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public float? Score { get; set; }
        public string? Comment { get; set; }
        public virtual User? RatingUser { get; set; }
        public virtual Product? Product { get; set; }
    }
}
