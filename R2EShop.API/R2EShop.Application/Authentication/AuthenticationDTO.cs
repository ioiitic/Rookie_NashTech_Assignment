using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Authentication
{
    public class AuthenticationDTO
    {
        public record AuthenticationResult(User user, string token);
    }
}
