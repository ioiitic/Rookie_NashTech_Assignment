using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.CQRS.Authentication.AuthenticationDTO;

namespace R2EShop.Application.CQRS.Authentication.Queries.Login
{
    public record LoginQuery(string token) : IRequest<AuthenticationResult>;
}
