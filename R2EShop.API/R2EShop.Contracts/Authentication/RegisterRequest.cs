using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.Authentication
{
    public record RegisterRequest(
        string Fullname,
        string EmailAddress,
        Address Address,
        string PhoneNumber,
        string PhotoUrl);
}
