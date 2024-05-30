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

namespace R2EShop.Application.CQRS.PhoneCases.Queries.GetNewPhoneCases
{
    public class GetNewPhoneCasesQueryHandler : IRequestHandler<GetNewPhoneCasesQuery, ErrorOr<IList<PhoneCase>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNewPhoneCasesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to get list new phone cases
        public async Task<ErrorOr<IList<PhoneCase>>> Handle(GetNewPhoneCasesQuery request, CancellationToken cancellationToken)
        {
            // 1. Set up Specification
            var spec = new Specification<PhoneCase>();

            // 2. Get list new phone cases
            var newPhoneCases = await _unitOfWork.PhoneCases.FindAsync(spec);

            return newPhoneCases.ToList();
        }
    }
}
