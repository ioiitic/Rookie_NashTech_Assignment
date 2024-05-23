using Mapster;
using R2EShop.Application.CQRS.Devices.Command.CreateDevice;
using R2EShop.Contracts.DeviceContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Mapping
{
    public class DeviceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Device, GetDeviceResponse>()
                .Map(desc => desc.ChildDevices,
                    src => src.Devices == null ? null : src.Devices.Select(dev => new { dev.Id, dev.DeviceName }).ToList());
            config.NewConfig<CreateDeviceRequest, CreateDeviceCommand>();
        }
    }
}
