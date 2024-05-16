using MediatR;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.Authentication.AuthenticationDTO;

namespace R2EShop.Application.Authentication.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private IGenericRepository<User> _genericRepository;

        public RegisterCommandHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate the user doesn't exist
            var existUser = await _genericRepository.FindAsync(u => u.EmailAddress == request.EmailAddress);
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

            await _genericRepository.AddAsync(user);

            // 3. Create JWT Token

            return new(user, "");
        }
    }
}
