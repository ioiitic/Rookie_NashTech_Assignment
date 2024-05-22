//using Azure.Core;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using R2EShop.Application.CQRS.Authentication.Command.Register;
//using R2EShop.Application.CQRS.Products.Command.CreateProduct;
//using R2EShop.Application.CQRS.Products.Queries.GetProducts;
//using R2EShop.Contracts.Product;
//using R2EShop.Domain.Entities;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

//namespace R2EShop.API.Controllers
//{
//    [ApiController]
//    [Route("products")]
//    public class ProductController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public ProductController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpGet]
//        public async Task<ActionResult> GetAll(
//            [FromQuery] int? page,
//            [FromQuery] int? pageSize,
//            [FromQuery] string? search,
//            [FromQuery] int? minPrice,
//            [FromQuery] int? maxPrice,
//            [FromQuery] string[] categoryIds)
//        {
//            // 1. Set up query
//            var query = new GetProductsQuery(page, pageSize, search, minPrice, maxPrice, categoryIds);

//            // 2. Get list products
//            var products = await _mediator.Send(query);

//            return products.MatchFirst(
//                Ok,
//                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
//        {
//            // 1. Set up command
//            var command = new CreateProductCommand(
//                request.ProductName,
//                request.Description,
//                request.ProductPrice,
//                request.PhotoUrl,
//                request.Categories);

//            // 2. Create product
//            var createProduct = await _mediator.Send(command);

//            return createProduct.MatchFirst(
//                createProduct => Ok(createProduct),
//                error => Problem(statusCode: StatusCodes.Status409Conflict, title: error.Description));
//        }
//    }
//}
