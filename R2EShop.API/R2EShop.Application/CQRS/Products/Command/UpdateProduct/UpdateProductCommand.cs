using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Command.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string ProductName,
        string Description,
        double ProductPrice,
        string PhotoUrl,
        IList<Guid> Categories) : IRequest<ErrorOr<Unit>>;
}
