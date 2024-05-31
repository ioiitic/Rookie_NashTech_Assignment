using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetArtwork
{
    public record GetArtworkQuery(Guid Id) : IRequest<ErrorOr<IList<object>>>;
}
