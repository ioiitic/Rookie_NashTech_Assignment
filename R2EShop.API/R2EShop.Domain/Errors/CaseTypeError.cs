using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Errors
{
    public static class CaseTypeError
    {
        public static Error DeviceNotExist => Error.NotFound(
            code: "CaseType.DeviceNotFound",
            description: "Device is not found.");
    }
}
