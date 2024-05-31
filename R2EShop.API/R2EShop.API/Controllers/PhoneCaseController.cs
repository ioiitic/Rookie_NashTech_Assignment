using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using R2EShop.API.Utils;
using R2EShop.Application.CQRS.PhoneCases.Command.CreatePhoneCase;
using R2EShop.Application.CQRS.PhoneCases.Queries.GetNewPhoneCases;
using R2EShop.Application.CQRS.PhoneCases.Queries.GetPhoneCase;
using R2EShop.Contracts.PhoneCaseContract;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("phonecases")]
    public class PhoneCaseController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PhoneCaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //SUMMARY: GET method to get new phone case
        //TODO: Validation request
        //[HttpGet]
        //public async Task<IActionResult> GetNew()
        //{
        //    // 1. Set up query
        //    var query = new GetNewPhoneCasesQuery();

        //    // 2. Get list phone case
        //    ErrorOr<IList<PhoneCase>> phoneCases = await _mediator.Send(query);

        //    return phoneCases.Match(
        //        phoneCases => Ok(MappingUtils.MapList<GetNewPhoneCaseResponse, PhoneCase>(phoneCases)),
        //        Problem);
        //}

        //SUMMARY: GET method to get phone case
        //TODO: Validation request
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNew(Guid id)
        {
            // 1. Set up query
            var query = new GetPhoneCaseQuery(id);

            // 2. Get list phone case
            ErrorOr<PhoneCase> phoneCase = await _mediator.Send(query);

            return phoneCase.Match(
                phoneCase => Ok(_mapper.Map<GetPhoneCaseResponse>(phoneCase)),
                Problem);
        }

        //SUMMARY: POST method to create phone case
        //TODO: Validation request
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhoneCaseRequest request)
        {
            var command = _mapper.Map<CreatePhoneCaseCommand>(request);

            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(),
                Problem);
        }
    }
}
