using ErrorOr;
using MediatR;
using Microsoft.Extensions.Configuration;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Artworks.Command.CreateArtwork
{
    public class CreateArtworkCommandHandler : IRequestHandler<CreateArtworkCommand, ErrorOr<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public CreateArtworkCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ErrorOr<Unit>> Handle(CreateArtworkCommand request, CancellationToken cancellationToken)
        {
            // 1. Create artwork
            Artwork newArtwork = new Artwork
            {
                ArtworkName = request.ArtworkName,
                IsNew = true,
                IsActive = true,
            };

            await _unitOfWork.Artworks.AddAsync(newArtwork);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
