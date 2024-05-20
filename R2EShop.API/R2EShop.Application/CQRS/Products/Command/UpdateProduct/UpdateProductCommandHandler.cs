using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.CQRS.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // 1. Set up Specification
            var spec = new Specification<Product>();
            spec.AddFilter(p => p.Id == request.Id);

            // 2. Get update product
            var updateProduct = await _unitOfWork.Products.FindFirstOrDefaultAsync(spec);

            // 3. Check exist update product
            if (updateProduct is null)
            {
                throw new Exception();
            }

            // 4. Update product
            updateProduct.ProductName = request.ProductName;
            updateProduct.ProductPrice = request.ProductPrice;

            return Unit.Value;
        }
    }
}
