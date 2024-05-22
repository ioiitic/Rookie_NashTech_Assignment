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
            config.NewConfig<Device, GetDeviceResponse>();
            config.NewConfig<CreateDeviceRequest, CreateDeviceCommand>();
        }
    }
}
