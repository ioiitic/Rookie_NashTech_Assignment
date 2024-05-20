

using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;

namespace R2EShop.Application.CQRS.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<Category>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // 1. Get list category
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return categories.ToList();
        }
    }
}