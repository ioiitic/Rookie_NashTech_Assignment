using MediatR;
using R2EShop.Application.Interface.Common;
using R2EShop.Domain.Entities;
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
            // 1. Validate the user doesn't exist
            var existUser = await _uow.Users.FindFirstOrDefaultAsync(u => u.EmailAddress == request.EmailAddress);
            if (existUser is not null)
            {
                throw new Exception("User already exist");
            }

            // 2. Create user
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

            // 3. Create JWT Token

            return new(user, "");
        }
    }
}
