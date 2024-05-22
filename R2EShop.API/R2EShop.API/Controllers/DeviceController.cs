using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("device")]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET Method to get all device as tree
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            // 1. Set up query
            var query = new GetDevicesQuery();

            // 2. Get list devices
            var devices = await _mediator.Send(query);
        }
    }
}
