using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.CaseColors.Command.CreateCaseColor
{
    public class CreateCaseColorCommandHandler : IRequestHandler<CreateCaseColorCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCaseColorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to create new case color
        public async Task<ErrorOr<Unit>> Handle(CreateCaseColorCommand request, CancellationToken cancellationToken)
        {
            // 1. Create case color
            var newCaseColor = new CaseColor
            {
                CaseColorName = request.CaseColorName,
                ImageUrl = request.ImageUrl,
                IsActive = true,
            };
            await _unitOfWork.CaseColors.AddAsync(newCaseColor);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
