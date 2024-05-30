using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.ArtworkContract
{
    public record GetArtworksRequest(
        string Search = "",
        int MinPrice = 0,
        int MaxPrice = 999999999,
        IList<string>? CategoryIds = null,
        IList<string>? DeviceIds = null,
        IList<string>? CaseTypeIds = null,
        IList<string>? CaseColorIds = null,
        string SortBy = "",
        bool IsAscending = false,
        int Page = 1,
        int PageSize = 100);
}
