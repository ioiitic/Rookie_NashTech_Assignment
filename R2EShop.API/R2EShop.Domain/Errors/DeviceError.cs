using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Errors
{
    public static class DeviceError
    {
        public static Error ParentNotExist => Error.NotFound(
            code: "Device.ParentNotFound",
            description: "Device parent is not found.");
        public static Error NotExist => Error.NotFound(
            code: "Device.NotFound",
            description: "Device is not found.");
    }
}
