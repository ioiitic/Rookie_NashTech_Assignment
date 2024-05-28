using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetNewArtworks
{
    public class GetNewArtworksQueryHandler : IRequestHandler<GetNewArtworksQuery, ErrorOr<IList<Object>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNewArtworksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<Object>>> Handle(GetNewArtworksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Artworks.GetNewArtWork();

            return result.ToList();
        }
    }
}
