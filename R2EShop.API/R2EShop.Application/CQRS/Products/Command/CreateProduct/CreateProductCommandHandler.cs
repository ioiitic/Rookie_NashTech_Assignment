using MediatR;
using Microsoft.Extensions.DependencyInjection;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IServiceProvider serviceProvider, IUnitOfWork unitOfWork)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            IList<Category> listCategories = new List<Category>();
            // 1. Handle list categories is not null
            if (request.Categories.Count() > 0)
            {
                // 1.1. Create list categories
                foreach(Guid catId  in request.Categories)
                {
                    var spec = new Specification<Category>();
                    spec.AddFilter(c => c.Id == catId);
                    var category = await _unitOfWork.Categories.FindFirstOrDefaultAsync(spec);
                    if (category is null)
                    {
                        throw new Exception();
                    }

                    listCategories.Add(category);
                }
            }

            // 2. Create new product
            Product newProduct = new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                ProductPrice = request.ProductPrice,
                PhotoUrl = request.PhotoUrl,
                Categories = listCategories,
            };

            // 3. Add Product
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
