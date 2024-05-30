using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using R2EShop.API.Utils;
using R2EShop.Application.CQRS.PhoneCases.Queries.GetNewPhoneCases;
using R2EShop.Domain.Entities;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("phonecases")]
    public class PhoneCaseController
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
    }
}
