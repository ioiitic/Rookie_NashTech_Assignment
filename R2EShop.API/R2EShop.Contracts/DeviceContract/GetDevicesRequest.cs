using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.DeviceContract
{
    public record GetDevicesRequest(string filter, string range, string sort);
}
