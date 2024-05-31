using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Interface.Repositories
{
    public interface IArtworkRepository : IGenericRepository<Artwork>
    {
        IEnumerable<object> GetArtworks(
            string search,
            int minPrice,
            int maxPrice,
            bool IsNew,
            bool IsTrending,
            IList<string>? categoryIds,
            IList<string>? deviceIds,
            IList<string>? caseTypeIds,
            IList<string>? caseColorIds,
            string sortBy,
            bool isAscending,
            int page,
            int pageSize);

        IEnumerable<object> GetArtwork(Guid id);
    }
}
