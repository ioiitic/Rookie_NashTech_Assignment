using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.UpdateDevice
{
    public record UpdateDeviceCommand(
        Guid Id,
        string DeviceName) : IRequest<ErrorOr<Unit>>;
}
