using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Queries.GetProducts
{
    public record GetProductsQuery(
        int? page,
        int? pageSize,
        string search,
        int? minPrice,
        int? maxPrice,
        string[] categoryIds) : IRequest<IList<Product>>;
}
