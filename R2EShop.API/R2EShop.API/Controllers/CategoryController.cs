using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.Categories.Command.CreateCategory;
using R2EShop.Application.CQRS.Categories.Command.UpdateCategory;
using R2EShop.Application.CQRS.Categories.Queries.GetCategories;
using R2EShop.Contracts.Category;
using R2EShop.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("cat")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            // 1. Set up query
            var query = new GetCategoriesQuery();

            // 2. Get list categories
            var categories = await _mediator.Send(query);

            return categories.MatchFirst(
                Ok,
                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryRequest request)
        {
            // 1. Set up command
            var command = new CreateCategoryCommand(
                request.CategoryName,
                request.PhotoUrl);

            // 2. Create Category
            var createCategory = await _mediator.Send(command);

            return createCategory.MatchFirst(
                createCategory => Ok(createCategory),
                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult> Update([FromRoute] string Id, [FromBody] CategoryRequest request)
        {
            // 1. Set up command
            var command = new UpdateCategoryCommand(
                Guid.Parse(Id),
                request.CategoryName,
                request.PhotoUrl);

            // 2. Update Category
            var updateCategory = await _mediator.Send(command);

            return updateCategory.MatchFirst(
                updateCategory => Ok(updateCategory),
                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
        }
    }
}
