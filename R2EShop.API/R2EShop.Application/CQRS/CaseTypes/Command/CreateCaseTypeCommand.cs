using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.CaseTypes.Command
{
    public record CreateCaseTypeCommand(
        string CaseTypeName,
        int Protection,
        int Weight,
        string ImageUrl,
        Guid DeviceId) : IRequest<ErrorOr<Unit>>;
}
