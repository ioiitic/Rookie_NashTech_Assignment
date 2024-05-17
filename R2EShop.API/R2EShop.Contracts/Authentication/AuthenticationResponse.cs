using R2EShop.Domain.Entities;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.Authentication
{
    public record AuthenticationResponse(
        User user,
        string token);
}
