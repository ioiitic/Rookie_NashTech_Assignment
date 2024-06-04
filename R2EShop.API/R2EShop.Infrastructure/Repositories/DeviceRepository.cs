using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Common;
using R2EShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace R2EShop.Infrastructure.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<object>> GetDevices()
        {
            var devices = await _context.Device
                .Include(dev => dev.Devices)
                    .ThenInclude(cdev => cdev.Devices)
                .Where(dev => dev.ParentDeviceId == null)
                .Select(dev => new
                {
                    dev.Id,
                    dev.DeviceName,
                    Devices = dev.Devices.Select(child => new
                    {
                        child.Id,
                        child.DeviceName,
                        Devices = child.Devices.Select(childChild => new
                        {
                            childChild.Id,
                            childChild.DeviceName
                        })
                    })
                })
                .ToListAsync(); 

            return devices;
        }
    }
}
