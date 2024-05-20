using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Errors
{
    public static class ProductError
    {
        public static Error NotExist => Error.NotFound(
            code: "Product.NotFound",
            description: "Product is not found.");
    }
}
