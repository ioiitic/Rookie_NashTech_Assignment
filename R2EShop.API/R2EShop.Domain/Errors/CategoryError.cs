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
        public static Error ParentNotExist => Error.NotFound(
            code: "Category.ParentNotFound",
            description: "Category parent is not found.");
    }
}
