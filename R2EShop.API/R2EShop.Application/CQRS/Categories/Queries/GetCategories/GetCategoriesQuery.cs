using ErrorOr;
using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Categories.Queries.GetCategories
{
    public record GetCategoriesQuery() : IRequest<ErrorOr<IList<Category>>>;
}
