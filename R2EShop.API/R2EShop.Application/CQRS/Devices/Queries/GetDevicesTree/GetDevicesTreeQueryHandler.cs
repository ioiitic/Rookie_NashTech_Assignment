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

namespace R2EShop.Application.CQRS.Devices.Queries.GetDevicesTree
{
    public class GetDevicesTreeQueryHandler 
        : IRequestHandler<GetDevicesTreeQuery, ErrorOr<IList<object>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDevicesTreeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<object>>> Handle(GetDevicesTreeQuery request, CancellationToken cancellationToken)
        {
            // 1. Get devices
            var devices = await _unitOfWork.Devices.GetDevices();

            return devices.ToList();
        }
    }
}
