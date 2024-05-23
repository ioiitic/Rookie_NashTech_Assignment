using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.CaseColors.Command.CreateCaseColor
{
    public record CreateCaseColorCommand(
        string CaseColorName,
        string ImageUrl) : IRequest<ErrorOr<Unit>>;
}
