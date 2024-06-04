using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.UpdateDevice
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDeviceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _unitOfWork.Devices.GetByIdAsync(request.Id);

            if (device is null)
            {
                return DeviceError.NotExist;
            }

            var updateDevice = device;
            updateDevice.DeviceName = request.DeviceName;

            _unitOfWork.Devices.Update(device, updateDevice);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
