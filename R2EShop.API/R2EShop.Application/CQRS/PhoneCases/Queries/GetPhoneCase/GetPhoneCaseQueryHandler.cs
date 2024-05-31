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

namespace R2EShop.Application.CQRS.PhoneCases.Queries.GetPhoneCase
{
    public class GetPhoneCaseQueryHandler : IRequestHandler<GetPhoneCaseQuery, ErrorOr<PhoneCase>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPhoneCaseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<PhoneCase>> Handle(GetPhoneCaseQuery request, CancellationToken cancellationToken)
        {
            var spec = new Specification<PhoneCase>();
            spec.AddFilter(pc => pc.Id == request.Id);
            spec.Include(pc => pc.Images);

            var phoneCase = await _unitOfWork.PhoneCases.FindFirstOrDefaultAsync(spec);

            if (phoneCase is null)
            {
                return PhoneCaseError.NotFound;
            }

            return phoneCase;
        }
    }
}
