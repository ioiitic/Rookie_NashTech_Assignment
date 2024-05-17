using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Products.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public CreateProductCommandHandler(
            IGenericRepository<Product> productRepository,
            IGenericRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
