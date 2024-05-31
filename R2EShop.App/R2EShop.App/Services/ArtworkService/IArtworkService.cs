using R2EShop.App.ViewModel;

namespace R2EShop.App.Services.ArtworkService
{
    public interface IArtworkService
    {
        Task<IList<ArtworkModel>> GetArtworksAsync(
            string? Search,
            int MinPrice,
            int MaxPrice,
            IList<string>? CategoryIds,
            IList<string>? DeviceIds,
            IList<string>? CaseTypeIds,
            IList<string>? CaseColorIds,
            string? SortBy,
            bool? IsAscending,
            int Page,
            int PageSize);
    }
}
