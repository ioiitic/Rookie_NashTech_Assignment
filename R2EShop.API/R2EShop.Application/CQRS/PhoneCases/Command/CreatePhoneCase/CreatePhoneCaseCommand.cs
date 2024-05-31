using ErrorOr;
using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.PhoneCases.Command.CreatePhoneCase
{
    public record CreatePhoneCaseCommand(
        string PhoneCaseName,
        double PhoneCasePrice,
        Guid DeviceId,
        Guid CaseTypeId,
        Guid CaseColorId,
        Guid ArtworkId,
        IList<string> Images,
        IList<Guid> CategoryIds) : IRequest<ErrorOr<Unit>>;
}
