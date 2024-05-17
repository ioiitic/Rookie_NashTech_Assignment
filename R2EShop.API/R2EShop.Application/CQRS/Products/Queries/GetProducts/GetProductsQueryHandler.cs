using LinqKit;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using R2EShop.Application.CQRS.Authentication.Queries.Login;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IList<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            // 1. Set up Specification for filter
            var spec = new Specification<Product>();

            // 2. Check for search request
            if (!string.IsNullOrEmpty(request.search))
            {
                spec.AddFilter(p => p.ProductName.Contains(request.search));
            }

            // 3. Check for price range request
            if (request.minPrice is not null)
            {
                spec.AddFilter(p => p.ProductPrice > request.minPrice);
            }

            if (request.maxPrice is not null)
            {
                spec.AddFilter(p => p.ProductPrice < request.maxPrice);
            }

            // 4. Check for category array
            //if (request.categoryIds.Count() > 0)
            //{
            //    spec.AddFilter(prod)
            //    request.categoryIds.All(catId => spec.AddFilter( => p.Categories.));
            //}

            // 5. Get products
            var products = await _productRepository.FindAsync(spec);

            return products.ToList();
        }
    }
}
