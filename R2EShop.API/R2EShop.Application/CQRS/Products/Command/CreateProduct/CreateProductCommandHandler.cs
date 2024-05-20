using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // 1. Check categories list

            // 2. Get list categories
            var listCategories = new List<Category>();

            // 3. Create new product
            Product newProduct = new Product
            {
                ProductName = request.ProductName,
                Description = request.Description,
                ProductPrice = request.ProductPrice,
                PhotoUrl = request.PhotoUrl,
                Categories = listCategories,
            };

            // 4. Add Product
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
