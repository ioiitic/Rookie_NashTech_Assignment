using R2EShop.App.ViewModel;

namespace R2EShop.App.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IList<CategoryModel>> GetCategoriesAsync();
    }
}
