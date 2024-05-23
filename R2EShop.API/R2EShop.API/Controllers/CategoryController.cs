using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.API.Utils;
using R2EShop.Application.CQRS.Categories.Command.CreateCategory;
using R2EShop.Application.CQRS.Categories.Command.UpdateCategory;
using R2EShop.Application.CQRS.Categories.Queries.GetCategories;
using R2EShop.Contracts.Category;
using R2EShop.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        ///     GET Method get all categories as tree
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // 1. Set up query
            var query = new GetCategoriesQuery();

            // 2. Get list categories
            ErrorOr<IList<Category>> categories = await _mediator.Send(query);

            return categories.Match(
                categories => Ok(MappingUtils.MapList<GetCategoryResponse, Category>(categories, _mapper)),
                errors => Problem(errors));
        }

        /// <summary>
        ///     POST Method to create category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateCategoryCommand>(request);

            // 2. Create Category
            ErrorOr<Unit> createCategory = await _mediator.Send(command);

            return createCategory.Match(
                createCategory => Ok(),
                Problem);
        }

        //[HttpPost("{Id}")]
        //public async Task<IActionResult> Update([FromRoute] string Id, [FromBody] CategoryRequest request)
        //{
        //    // 1. Set up command
        //    var command = new UpdateCategoryCommand(
        //        Guid.Parse(Id),
        //        request.CategoryName,
        //        request.PhotoUrl);

        //    // 2. Update Category
        //    var updateCategory = await _mediator.Send(command);

        //    return updateCategory.MatchFirst(
        //        updateCategory => Ok(updateCategory),
        //        error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
        //}
    }
}
