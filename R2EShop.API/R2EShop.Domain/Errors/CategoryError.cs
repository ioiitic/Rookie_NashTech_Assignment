using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Errors
{
    public static class CategoryError
    {
        public static Error NotExist => Error.NotFound(
            code: "Category.NotFound",
            description: "Category is not found.");
    }
}
