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

namespace R2EShop.Application.CQRS.CaseTypes.Command
{
    public class CreateCaseTypeCommandHandler : IRequestHandler<CreateCaseTypeCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCaseTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to create case type
        public async Task<ErrorOr<Unit>> Handle(CreateCaseTypeCommand request, CancellationToken cancellationToken)
        {
            // 1. Check Device
            var specDevice = new Specification<Device>();
            specDevice.AddFilter(dev => dev.Id == request.DeviceId);
            var device = await _unitOfWork.Devices.FindFirstOrDefaultAsync(specDevice);
            if (device is null)
            {
                return CaseTypeError.DeviceNotExist;
            }

            // 2. Create case type
            CaseType newCaseType = new CaseType
            {
                CaseTypeName = request.CaseTypeName,
                Protection = request.Protection,
                Weight = request.Weight,
                Device = device,
                ImageUrl = request.ImageUrl,
                IsActive = true,
            };

            await _unitOfWork.CaseTypes.AddAsync(newCaseType);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
