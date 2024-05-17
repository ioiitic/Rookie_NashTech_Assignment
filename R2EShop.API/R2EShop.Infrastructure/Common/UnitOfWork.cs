using R2EShop.Application.Interface.Common;
using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(MyDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public IUserRepository Users => _userRepository;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
