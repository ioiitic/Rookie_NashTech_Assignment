using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.DeviceContract
{
    public record GetDevicesResponse(
        Guid Id,
        string DeviceName,
        Guid? ParentDeviceId);
}
