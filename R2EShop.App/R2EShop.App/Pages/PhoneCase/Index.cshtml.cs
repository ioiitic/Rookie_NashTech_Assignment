using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.App.Services.ArtworkService;
using R2EShop.App.Services.CategoryService;
using R2EShop.App.Services.DeviceService;
using R2EShop.App.ViewModel;

namespace R2EShop.App.Pages.PhoneCase
{
    public class IndexModel : BasePageModel
    {
        private readonly IArtworkService _artworkService;
        private readonly ICategoryService _categoryService;
        public IList<ArtworkModel> Artworks { get; set; }
        public IList<CategoryModel> Categories { get; set; }

        public IndexModel(IDeviceService deviceService, IArtworkService artworkService, ICategoryService categoryService) : base(deviceService)
        {
            Artworks = new List<ArtworkModel>();
            Categories = new List<CategoryModel>();
            _artworkService = artworkService;
            _categoryService = categoryService;
        }

        public async Task OnGet(
            [FromQuery] string? search = null,
            [FromQuery] int minPrice = 0,
            [FromQuery] int maxPrice = 0,
            [FromQuery] IList<string>? categoryIds = null,
            [FromQuery] IList<string>? deviceIds = null,
            [FromQuery] IList<string>? caseTypeIds = null,
            [FromQuery] IList<string>? caseColorIds = null,
            [FromQuery] string? sortBy = null,
            [FromQuery] bool? isAscending = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var categoriesTask =  _categoryService.GetCategoriesAsync();
            var artworksTask = _artworkService.GetArtworksAsync(
                search, minPrice, maxPrice, categoryIds, deviceIds, caseTypeIds, caseColorIds, sortBy, isAscending, page, pageSize);

            await Task.WhenAll(categoriesTask, artworksTask);

            Categories = await categoriesTask;
            Artworks = await artworksTask;
        }
    }
}
