using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Query.GetDevices
{
    public class GetDevicesQueryHandler 
        : IRequestHandler<GetDevicesQuery, ErrorOr<IList<Device>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDevicesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<Device>>> Handle(GetDevicesQuery request, CancellationToken cancellationToken)
        {
            // 1. Set up query
            var spec = new Specification<Device>();
            spec.AddFilter(dev => dev.ParentDeviceId == null);
            spec.Include(dev => dev.Devices);

            // 2. Get devices
            var devices = await _unitOfWork.Devices.FindAsync(spec);

            return devices.ToList();
        }
    }
}
