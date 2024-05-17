using MediatR;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static R2EShop.Application.CQRS.Authentication.AuthenticationDTO;

namespace R2EShop.Application.CQRS.Authentication.Command.Register
{
    public record RegisterCommand(
        string Fullname,
        string EmailAddress,
        Address Address,
        string PhoneNumber,
        string PhotoUrl) : IRequest<AuthenticationResult>;
}
