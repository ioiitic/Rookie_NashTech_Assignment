using Microsoft.AspNetCore.Mvc;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        //private MyDbContext _context = new MyDbContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            //var products = _context.Products.ToList();
            //return Ok(products);
            return Ok();
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
