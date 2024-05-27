using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.CategoryContract
{
    public record CreateCategoryRequest(
        string CategoryName,
        string? ParentCategoryId);
}
