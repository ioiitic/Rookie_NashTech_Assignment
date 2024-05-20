﻿using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 1. Set up Specification
            var spec = new Specification<Category>();
            spec.AddFilter(cat => cat.Id == request.Id);

            // 2. Get category
            Category updateCategory = await _unitOfWork.Categories.FindFirstOrDefaultAsync(spec);

            // 3. Check category is null
            if (updateCategory is null)
            {
                throw new Exception();
            }

            // 4. Update category
            updateCategory.CategoryName = request.CategoryName;
            updateCategory.PhotoUrl = request.PhotoUrl;
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
