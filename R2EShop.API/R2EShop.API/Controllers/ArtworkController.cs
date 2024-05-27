using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using R2EShop.Application.CQRS.Artworks.Command.CreateArtwork;
using R2EShop.Contracts.ArtworkContract;

namespace R2EShop.API.Controllers
{
    [ApiController]
    [Route("artworks")]
    public class ArtworkController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ArtworkController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //SUMMARY: GET method to get list of artwork by search name, filter category, pagination
        //TODO: All

        //SUMMARY: POST method to create new artwork
        //TODO: Validation request
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtworkRequest request)
        {
            // 1. Set up command
            var command = _mapper.Map<CreateArtworkCommand>(request);

            // 2. Create Artwork
            ErrorOr<Unit> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(),
                Problem);
        }
    }
}
