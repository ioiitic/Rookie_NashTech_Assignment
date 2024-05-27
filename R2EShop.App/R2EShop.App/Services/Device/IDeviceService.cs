using R2EShop.App.ViewModel;

namespace R2EShop.App.Services.Device
{
    public interface IDeviceService
    {
        Task<IList<DeviceModel>> GetDevicesAsync();
    }
}
