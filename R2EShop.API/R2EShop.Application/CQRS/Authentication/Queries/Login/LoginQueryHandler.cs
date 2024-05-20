using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.CQRS.Authentication.AuthenticationResult;

namespace R2EShop.Application.CQRS.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // 1. Validate the user exist
            // 2. Validate Google token
            // 3. Create JWT token
            return null;
        }
    }
}
