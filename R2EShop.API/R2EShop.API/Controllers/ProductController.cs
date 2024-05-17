using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.Authentication.Command.Register;
using R2EShop.Application.CQRS.Products.Queries.GetProducts;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(
            [FromQuery] int? page,
            [FromQuery] int? pageSize,
            [FromQuery] string? search,
            [FromQuery] int? minPrice,
            [FromQuery] int? maxPrice,
            [FromQuery] string[] categoryIds)
        {
            var command = new GetProductsQuery(page, pageSize, search, minPrice, maxPrice, categoryIds);

            var products = await _mediator.Send(command);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create()
        {
            //Product product = new Product();
            //product.Name = "123";
            //product.Category = null;
            //_context.Products.Add(product);
            //_context.SaveChanges();
            return Ok();
        }
    }
}
