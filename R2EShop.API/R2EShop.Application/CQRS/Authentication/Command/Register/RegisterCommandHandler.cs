using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
using R2EShop.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.CQRS.Authentication.AuthenticationDTO;

namespace R2EShop.Application.CQRS.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IUnitOfWork _uow;

        public RegisterCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // 1. Set up Specification for filter
            var spec = new Specification<User>();

            // 2. Check for search request
            if (!string.IsNullOrEmpty(request.EmailAddress))
            {
                spec.AddFilter(user => user.EmailAddress == request.EmailAddress);
            }

            // 3. Validate the user doesn't exist
            var existUser = await _uow.Users.FindFirstOrDefaultAsync(spec);
            if (existUser is not null)
            {
                throw new Exception("User already exist");
            }

            // 4. Create user
            var user = new User
            {
                Fullname = request.Fullname,
                EmailAddress = request.EmailAddress,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                PhotoUrl = request.PhotoUrl,
            };

            await _uow.Users.AddAsync(user);
            await _uow.SaveChangesAsync();

            // 5. Create JWT Token

            return new(user, "");
        }
    }
}
