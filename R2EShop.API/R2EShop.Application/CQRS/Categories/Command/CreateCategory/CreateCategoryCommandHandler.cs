using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Errors;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to create new category
        public async Task<ErrorOr<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category parentCategory = null;
            // 1. Validate parent category
            if (!string.IsNullOrEmpty(request.ParentCategoryId))
            {
                var spec = new Specification<Category>();
                spec.AddFilter(cat => cat.Id.ToString() == request.ParentCategoryId);

                parentCategory = await _unitOfWork.Categories.FindFirstOrDefaultAsync(spec);
                if (parentCategory is null)
                {
                    return CategoryError.ParentNotExist;
                }
            }

            // 2. Create category
            var newCategory = new Category
            {
                CategoryName = request.CategoryName,
                ParentCategoryId = parentCategory?.Id,
                IsActive = true,
            };
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
