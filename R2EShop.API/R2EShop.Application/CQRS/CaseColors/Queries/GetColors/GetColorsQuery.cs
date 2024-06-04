using ErrorOr;
using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.CaseColors.Queries.GetColors
{
    public record GetColorsQuery(
        string filter,
        string range,
        string sort) : IRequest<ErrorOr<IList<CaseColor>>>;
}
