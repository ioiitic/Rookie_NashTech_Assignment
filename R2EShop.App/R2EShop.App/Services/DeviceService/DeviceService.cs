using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using R2EShop.App.Services.Api;
using R2EShop.App.ViewModel;
using System.Net.Http;

namespace R2EShop.App.Services.DeviceService
{
    public class DeviceService : ApiService, IDeviceService
    {
        public DeviceService(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<IList<DeviceModel>> GetDevicesAsync()
        {
            var response = await _httpClient.GetAsync("devices");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<List<DeviceModel>>(responseBody.ToString());
        }
    }
}
