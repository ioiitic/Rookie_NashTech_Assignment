using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2EShop.App.Services.Api;
using R2EShop.App.ViewModel;
using System.Net.Http;
using System.Web;

namespace R2EShop.App.Services.ArtworkService
{
    public class ArtworkService : ApiService, IArtworkService
    {
        public ArtworkService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IList<ArtworkModel>> GetArtworksAsync(
            string Search,
            int MinPrice,
            int MaxPrice,
            IList<string>? CategoryIds,
            IList<string>? DeviceIds,
            IList<string>? CaseTypeIds,
            IList<string>? CaseColorIds,
            string? SortBy,
            bool? IsAscending,
            int Page,
            int PageSize)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(Search))
            {
                query["Search"] = Search;
            }

            if (MinPrice > 0)
            {
                query["MinPrice"] = MinPrice.ToString();
            }

            if (MaxPrice > 0)
            {
                query["MaxPrice"] = MaxPrice.ToString();
            }

            if (CategoryIds != null && CategoryIds.Any())
            {
                query["CategoryIds"] = string.Join(",", CategoryIds);
            }

            if (DeviceIds != null && DeviceIds.Any())
            {
                query["DeviceIds"] = string.Join(",", DeviceIds);
            }

            if (CaseTypeIds != null && CaseTypeIds.Any())
            {
                query["CaseTypeIds"] = string.Join(",", CaseTypeIds);
            }

            if (CaseColorIds != null && CaseColorIds.Any())
            {
                query["CaseColorIds"] = string.Join(",", CaseColorIds);
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                query["SortBy"] = SortBy;
            }

            if (IsAscending != null)
            {
                query["IsAscending"] = IsAscending.ToString();
            }

            query["Page"] = Page.ToString();
            query["PageSize"] = PageSize.ToString();

            var queryString = query.ToString();
            var requestUri = $"artworks?{queryString}";

            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<List<ArtworkModel>>(responseBody.ToString());
        }
    }
}
