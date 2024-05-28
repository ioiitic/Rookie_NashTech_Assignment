using ErrorOr;
using MediatR;
using R2EShop.Application.Interface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetTrendingArtworks
{
    public class GetTrendingArtworksQueryHandler : IRequestHandler<GetTrendingArtworksQuery, ErrorOr<IList<Object>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrendingArtworksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //SUMMARY: A service to get list trending artworks
        public async Task<ErrorOr<IList<Object>>> Handle(GetTrendingArtworksQuery request, CancellationToken cancellationToken)
        {
            var trendingArtworks = await _unitOfWork.Artworks.GetTrendingArtwork();

            return trendingArtworks.ToList();
        }
    }
}
