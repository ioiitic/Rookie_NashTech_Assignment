using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.CaseColors.Command.CreateCaseColor;
using R2EShop.Application.CQRS.CaseColors.Queries.GetColors;
using R2EShop.Application.CQRS.Devices.Queries.GetDevices;
using R2EShop.Contracts.CaseColorContract;
using R2EShop.Contracts.DeviceContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("casecolors")]
    public class CaseColorController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CaseColorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //TODO: Validation request
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetColorsRequest request)
        {
            // 1. Set up query
            var query = _mapper.Map<GetColorsQuery>(request);

            // 2. Get list devices
            ErrorOr<IList<CaseColor>> devices = await _mediator.Send(query);

            return devices.Match(
                devices => Ok(_mapper.Map<IList<GetColorsResponse>>(devices)),
                Problem);
        }

        //SUMMARY: POST method to create a case color
        //TODO: Validation request
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCaseColorRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateCaseColorCommand>(request);

            // 2. Create case color
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(),
                Problem);
        }
    }
}
