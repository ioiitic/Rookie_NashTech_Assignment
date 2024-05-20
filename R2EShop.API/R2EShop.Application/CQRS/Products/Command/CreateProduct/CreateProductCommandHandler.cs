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
    public class CreateProductCommandHandler : IRequest<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
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
            await _productRepository.AddAsync(newProduct);
        }
    }
}
