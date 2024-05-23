using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using R2EShop.API.Utils;
using R2EShop.Application.CQRS.Devices.Command.CreateDevice;
using R2EShop.Application.CQRS.Devices.Query.GetDevices;
using R2EShop.Contracts.DeviceContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DeviceController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        ///     GET Method to get device as tree
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // 1. Set up query
            var query = new GetDevicesQuery();

            // 2. Get list devices
            ErrorOr<IList<Device>> devices = await _mediator.Send(query);

            return devices.Match(
                devices => Ok(MappingUtils.MapList<GetDeviceResponse, Device>(devices, _mapper)),
                Problem);
        }

        // POST method to create a device
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeviceRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateDeviceCommand>(request);

            // 2. Create a device
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
                res => Ok(),
                Problem);
        }
    }
}
