using Microsoft.EntityFrameworkCore;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Common;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {

        }
    }
}
