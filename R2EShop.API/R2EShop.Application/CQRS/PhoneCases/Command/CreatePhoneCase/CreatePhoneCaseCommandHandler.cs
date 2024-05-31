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

namespace R2EShop.Application.CQRS.PhoneCases.Command.CreatePhoneCase
{
    public class CreatePhoneCaseCommandHandler : IRequestHandler<CreatePhoneCaseCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePhoneCaseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //TODO: Validate
        public async Task<ErrorOr<Unit>> Handle(CreatePhoneCaseCommand request, CancellationToken cancellationToken)
        {
            var spec = new Specification<Category>();
            spec.AddFilter(cat => request.CategoryIds.Contains(cat.Id));
            var categories = await _unitOfWork.Categories
                .FindAsync(spec);

            PhoneCase newPhoneCase = new PhoneCase
            {
                PhoneCaseName = request.PhoneCaseName,
                PhoneCasePrice = request.PhoneCasePrice,
                DeviceId = request.DeviceId,
                CaseTypeId = request.CaseTypeId,
                CaseColorId = request.CaseColorId,
                ArtworkId = request.ArtworkId,
                Images = request.Images.Select(img => new Image
                {
                    Url = img
                }).ToList(),
                Categories = categories.ToList()
            };
            await _unitOfWork.PhoneCases.AddAsync(newPhoneCase);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
