using ErrorOr;
using MediatR;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetArtworks
{
    public record GetArtworksQuery(
        string Search,
        int MinPrice,
        int MaxPrice,
        bool IsNew,
        bool IsTrending,
        IList<string>? CategoryIds,
        IList<string>? DeviceIds,
        IList<string>? CaseTypeIds,
        IList<string>? CaseColorIds,
        string SortBy,
        bool IsAscending,
        int Page,
        int PageSize) : IRequest<ErrorOr<IList<object>>>;
}
