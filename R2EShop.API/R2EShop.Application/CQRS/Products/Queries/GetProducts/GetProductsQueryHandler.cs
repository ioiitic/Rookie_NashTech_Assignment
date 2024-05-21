//using ErrorOr;
//using LinqKit;
//using MediatR;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using R2EShop.Application.CQRS.Authentication.Queries.Login;
//using R2EShop.Application.Interface.Common;
//using R2EShop.Application.Interface.Repositories;
//using R2EShop.Domain.Entities;
//using R2EShop.Domain.Specification;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace R2EShop.Application.CQRS.Products.Queries.GetProducts
//{
//    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ErrorOr<IList<PhoneCase>>>
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public GetProductsQueryHandler(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<ErrorOr<IList<PhoneCase>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
//        {
//            // 1. Set up Specification for filter
//            var spec = new Specification<PhoneCase>();

//            // 2. Check for search request
//            if (!string.IsNullOrEmpty(request.search))
//            {
//                spec.AddFilter(p => p.ProductName.Contains(request.search));
//            }

//            // 3. Check for price range request
//            if (request.minPrice is not null)
//            {
//                spec.AddFilter(p => p.ProductPrice > request.minPrice);
//            }

//            if (request.maxPrice is not null)
//            {
//                spec.AddFilter(p => p.ProductPrice < request.maxPrice);
//            }

//            // 4. Check for category array
//            if (request.categoryIds.Count() > 0)
//            {
//                spec.AddFilter(p => p.Categories.Any(c => request.categoryIds.Contains(c.Id.ToString())));
//            }

//            // 5. Get products
//            var products = await _unitOfWork.Products.FindAsync(spec);

//            return products.ToList();
//        }
//    }
//}
