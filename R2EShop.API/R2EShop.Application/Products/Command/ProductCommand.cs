using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Products.Command
{
    public record CreateProductCommand : IRequest<Product>
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public float? ProductPrice { get; set; }
        public string? PhotoUrl { get; set; }
        public virtual IList<Guid>? Categories { get; set; }
    }
}
