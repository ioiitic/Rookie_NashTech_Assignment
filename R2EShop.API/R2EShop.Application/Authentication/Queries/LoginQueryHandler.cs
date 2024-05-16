using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.Authentication.AuthenticationDTO;

namespace R2EShop.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        public Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // 1. Validate the user exist
            // 2. Validate Google token
            // 3. Create JWT token
            return null;
        }
    }
}
