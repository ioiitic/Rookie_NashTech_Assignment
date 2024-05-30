using R2EShop.App.ViewModel;

namespace R2EShop.App.Services.DeviceService
{
    public interface IDeviceService
    {
        Task<IList<DeviceModel>> GetDevicesAsync();
    }
}
