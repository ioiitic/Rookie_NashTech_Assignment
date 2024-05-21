using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.Product
{
    public record CreateProductRequest(
        string ProductName,
        string Description,
        double ProductPrice,
        string PhotoUrl,
        IList<Guid> Categories);
}
