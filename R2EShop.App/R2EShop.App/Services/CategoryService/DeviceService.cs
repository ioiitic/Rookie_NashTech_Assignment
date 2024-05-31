using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2EShop.App.Services.Api;
using R2EShop.App.ViewModel;
using System.Net.Http;

namespace R2EShop.App.Services.CategoryService
{
    public class CategoryService : ApiService, ICategoryService
    {
        public CategoryService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IList<CategoryModel>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("categories");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<List<CategoryModel>>(responseBody.ToString());
        }
    }
}
