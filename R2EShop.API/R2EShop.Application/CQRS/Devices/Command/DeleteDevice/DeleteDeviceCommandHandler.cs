using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Devices.Command.DeleteDevice
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeviceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _unitOfWork.Devices.GetByIdAsync(request.Id);

            if (device is null)
            {
                return DeviceError.NotExist;
            }

            _unitOfWork.Devices.Delete(device);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
