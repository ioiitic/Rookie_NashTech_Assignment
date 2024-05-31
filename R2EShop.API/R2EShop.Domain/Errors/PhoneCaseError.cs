using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Errors
{
    public static class PhoneCaseError
    {
        public static Error NotFound => Error.NotFound(
            code: "PhoneCase.NotFound",
            description: "Phone case is not found.");
    }
}
