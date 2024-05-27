using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.DeviceContract
{
    public record CreateDeviceRequest(
        string DeviceName,
        string? ParentDeviceId);
}
