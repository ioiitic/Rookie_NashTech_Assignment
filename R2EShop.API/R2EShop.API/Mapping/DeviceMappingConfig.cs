using Mapster;
using R2EShop.Application.CQRS.Categories.Queries.GetCategories;
using R2EShop.Application.CQRS.Devices.Command.CreateDevice;
using R2EShop.Contracts.CategoryContract;
using R2EShop.Contracts.DeviceContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Mapping
{
    public class DeviceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<Device, GetDevicesResponse>()
            //    .Map(desc => desc.ChildDevices,
            //        src => src.Devices == null ? null : src.Devices.Select(dev => new { dev.Id, dev.DeviceName }).ToList());
            config.NewConfig<Category, GetCategoriesResponse>()
                .Map(desc => desc.ChildCategories,
                    src => src.Categories == null ? null : src.Categories.Select(dev => new { dev.Id, dev.CategoryName }).ToList());
        }
    }
}
