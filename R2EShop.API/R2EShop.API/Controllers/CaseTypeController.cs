using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.API.Utils;
using R2EShop.Application.CQRS.CaseTypes.Command;
using R2EShop.Application.CQRS.CaseTypes.Queries.GetCaseTypes;
using R2EShop.Contracts.CaseTypeContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("casetypes")]
    public class CaseTypeController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CaseTypeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //SUMMARY: GET method to get list case types by device
        //TODO: Validation request
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetCaseTypesRequest request)
        {
            // 1. Set up query
            var query = new GetCaseTypesQuery(request.DeviceId);

            // 2. Get list case types
            ErrorOr<IList<CaseType>> caseTypes = await _mediator.Send(query);

            return caseTypes.Match(
                caseTypes => Ok(MappingUtils.MapList<GetCaseTypeResponse, CaseType>(caseTypes, _mapper)),
                Problem);
        }

        //SUMMARY: POST method to create case type
        //TODO: Validation request
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCaseTypeRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateCaseTypeCommand>(request);

            // 2. Create case type
            ErrorOr<Unit> caseType = await _mediator.Send(command);

            return caseType.Match(
                caseType => Ok(),
                Problem);
        }
    }
}
