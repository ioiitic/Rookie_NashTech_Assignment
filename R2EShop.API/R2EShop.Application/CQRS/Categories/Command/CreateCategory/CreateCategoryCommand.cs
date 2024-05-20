using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Categories.Command.CreateCategory
{
    public record CreateCategoryCommand(
        string CategoryName,
        string PhotoUrl) : IRequest<Unit>;
}
