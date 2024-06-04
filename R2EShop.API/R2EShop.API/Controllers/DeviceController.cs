using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.Devices.Command.CreateDevice;
using R2EShop.Application.CQRS.Devices.Queries.GetDevices;
using R2EShop.Application.CQRS.Devices.Queries.GetDevicesTree;
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

        //TODO: Validation request
        [HttpGet("astree")]
        public async Task<IActionResult> GetAll()
        {
            // 1. Set up query
            var query = new GetDevicesTreeQuery();

            // 2. Get list devices
            ErrorOr<IList<object>> devices = await _mediator.Send(query);

            return devices.Match(
                devices => Ok(devices),
                Problem);
        }

        //TODO: Validation request
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetDevicesRequest request)
        {
            // 1. Set up query
            var query = _mapper.Map<GetDevicesQuery>(request);

            // 2. Get list devices
            ErrorOr<IList<Device>> devices = await _mediator.Send(query);

            return devices.Match(
                devices => Ok(_mapper.Map<IList<GetDevicesResponse>>(devices)),
                Problem);
        }

        //SUMMARY: POST method to create a device
        //TODO: Validation request
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

        //SUMMARY: PUT method to update a device
        //TODO: All
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] CreateDeviceRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateDeviceCommand>(request);

            // 2. Create a device
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
                res => Ok(),
                Problem);
        }

        //SUMMARY: DELETE method to delete a device
        //TODO: All
    }
}
