using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.CaseColors.Queries.GetColors
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, ErrorOr<IList<CaseColor>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetColorsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<CaseColor>>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
        {
            var colors = await _unitOfWork.CaseColors.GetAllAsync();

            return colors.ToList();
        }
    }
}
