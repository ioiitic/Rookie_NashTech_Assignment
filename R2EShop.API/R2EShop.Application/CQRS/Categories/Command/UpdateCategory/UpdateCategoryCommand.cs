using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Categories.Command.UpdateCategory
{
    public record UpdateCategoryCommand(
        Guid Id,
        string CategoryName,
        string PhotoUrl) : IRequest<Unit>;
}
