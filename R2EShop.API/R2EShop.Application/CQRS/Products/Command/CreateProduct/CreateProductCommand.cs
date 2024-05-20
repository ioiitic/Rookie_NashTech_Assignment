using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Command.CreateProduct
{
    public record CreateProductCommand
    (
        string ProductName,
        string Description,
        double ProductPrice,
        string PhotoUrl,
        IList<Guid>? Categories
    ) : IRequest<Unit>;
}
