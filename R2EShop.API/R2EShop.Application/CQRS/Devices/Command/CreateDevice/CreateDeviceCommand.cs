using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.CreateDevice
{
    public record CreateDeviceCommand(
        string DeviceName,
        string? ParentDeviceId) : IRequest<ErrorOr<Unit>>;
}
