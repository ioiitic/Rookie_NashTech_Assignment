using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.Category
{
    public record CategoryRequest(
        string CategoryName,
        string PhotoUrl);
}
