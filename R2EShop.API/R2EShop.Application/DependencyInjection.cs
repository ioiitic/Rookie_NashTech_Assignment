using MediatR;
using Microsoft.Extensions.DependencyInjection;
using R2EShop.Application.CQRS.Artworks.Queries.GetNewArtworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddMediatR(typeof(GetNewArtworksQueryHandler).Assembly);

            return services;
        }
    }
}
