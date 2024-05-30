using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2EShop.App.Services.Api;
using R2EShop.App.ViewModel;
using System.Net.Http;

namespace R2EShop.App.Services.Artwork
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
            string SortBy,
            bool IsAscending,
            int Page,
            int PageSize)
        {
            var response = await _httpClient.GetAsync("artworks");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<List<ArtworkModel>>(responseBody.ToString());
        }
    }
}
