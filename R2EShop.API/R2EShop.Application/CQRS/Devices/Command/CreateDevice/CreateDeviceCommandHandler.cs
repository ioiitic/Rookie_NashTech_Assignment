using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Errors;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.CreateDevice
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDeviceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            Device parentDevice = null;
            // 1. Validate parent device
            if (!string.IsNullOrEmpty(request.ParentDeviceId))
            {
                var spec = new Specification<Device>();
                spec.AddFilter(dev => dev.Id.ToString() == request.ParentDeviceId);

                parentDevice = await _unitOfWork.Devices.FindFirstOrDefaultAsync(spec);
                if (parentDevice is null)
                {
                    return DeviceError.NotExist;
                }
            }

            // 2. Create device
            var newDevice = new Device
            {
                DeviceName = request.DeviceName,
                ParentDeviceId = parentDevice?.Id,
                IsActive = true
            };
            await _unitOfWork.Devices.AddAsync(newDevice);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
