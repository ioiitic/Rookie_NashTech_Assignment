using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Command.CreateArtwork
{
    public record CreateArtworkCommand(
        string ArtworkName) : IRequest<ErrorOr<Unit>>;
}
