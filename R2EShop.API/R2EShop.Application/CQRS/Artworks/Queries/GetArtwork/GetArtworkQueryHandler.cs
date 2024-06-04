using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetArtwork
{
    public class GetArtworkQueryHandler : IRequestHandler<GetArtworkQuery, ErrorOr<IList<object>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetArtworkQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<object>>> Handle(GetArtworkQuery request, CancellationToken cancellationToken)
        {
            var artwork = _unitOfWork.Artworks.GetArtwork(request.Id);

            return artwork.ToList();
        }
    }
}
