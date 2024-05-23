using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;

namespace R2EShop.Application.CQRS.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler 
        : IRequestHandler<GetCategoriesQuery, ErrorOr<IList<Category>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to get all categories
        public async Task<ErrorOr<IList<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // 1. Set up query
            var spec = new Specification<Category>();
            spec.AddFilter(cat => cat.ParentCategoryId == null);
            spec.Include(cat => cat.Categories);

            // 2. Get categories
            var categories = await _unitOfWork.Categories.FindAsync(spec);

            return categories.ToList();
        }
    }
}