using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.DeleteDevice
{
    public record DeleteDeviceCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
