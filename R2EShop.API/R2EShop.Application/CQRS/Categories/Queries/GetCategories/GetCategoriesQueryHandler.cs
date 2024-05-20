

using MediatR;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;

namespace R2EShop.Application.CQRS.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IList<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            // 1. Get list category
            var categories = await _categoryRepository.GetAllAsync();

            return categories.ToList();
        }
    }
}