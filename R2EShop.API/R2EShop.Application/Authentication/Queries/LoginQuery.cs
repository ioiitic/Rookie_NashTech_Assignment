using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.Authentication.AuthenticationDTO;

namespace R2EShop.Application.Authentication.Queries
{
    public record LoginQuery(string token) : IRequest<AuthenticationResult>;
}
