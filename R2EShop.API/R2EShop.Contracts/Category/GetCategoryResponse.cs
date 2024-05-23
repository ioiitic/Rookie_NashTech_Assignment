using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.Category
{
    public record GetCategoryResponse(
        Guid Id,
        string CategoryName,
        IList<GetCategoryResponse> ChildCategories);
}
