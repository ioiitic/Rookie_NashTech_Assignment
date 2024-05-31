using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Queries.GetArtworks
{
    public class GetArtworksQueryHandler : IRequestHandler<GetArtworksQuery, ErrorOr<IList<object>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetArtworksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<IList<object>>> Handle(GetArtworksQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.Artworks.GetArtworks(
                request.Search,
                request.MinPrice,
                request.MaxPrice,
                request.IsNew,
                request.IsTrending,
                request.CategoryIds,
                request.DeviceIds,
                request.CaseTypeIds,
                request.CaseColorIds,
                request.SortBy,
                request.IsAscending,
                request.Page,
                request.PageSize);

            return products.ToList();
        }
    }
}
