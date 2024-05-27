namespace R2EShop.App.Services.Api
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
