using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2EShop.App.Services.Api;
using R2EShop.App.ViewModel;
using System.Net.Http;

namespace R2EShop.App.Services.Device
{
    public class DeviceService : ApiService, IDeviceService
    {
        public DeviceService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IList<DeviceModel>> GetDevicesAsync()
        {
            _httpClient.BaseAddress = new Uri("http://localhost:3001/");
            var response = await _httpClient.GetAsync("devices");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<List<DeviceModel>>(responseBody.ToString());
        }
    }
}
