using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
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

        public async Task<ErrorOr<Unit>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Create new category
            Category newCategory = new Category
            {
                CategoryName = request.CategoryName,
            };

            // 2. Create category
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
