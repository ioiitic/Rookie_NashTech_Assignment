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

namespace R2EShop.Application.CQRS.CaseTypes.Queries.GetCaseTypes
{
    public class GetCaseTypesQueryHandler
        : IRequestHandler<GetCaseTypesQuery, ErrorOr<IList<CaseType>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCaseTypesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to get list case types
        public async Task<ErrorOr<IList<CaseType>>> Handle(GetCaseTypesQuery request, CancellationToken cancellationToken)
        {
            // 1. Check Device
            var specDevice = new Specification<Device>();
            specDevice.AddFilter(dev => dev.Id == request.DeviceId);
            var device = await _unitOfWork.Devices.FindFirstOrDefaultAsync(specDevice);
            if (device is null)
            {
                return CaseTypeError.DeviceNotExist;
            }

            // 2. Set up query
            var specCaseType = new Specification<CaseType>();
            specCaseType.AddFilter(ct => request.DeviceId == ct.Device.Id);

            // 3. Get case types
            var casetypes = await _unitOfWork.CaseTypes.FindAsync(specCaseType);

            return casetypes.ToList();
        }
    }
}
