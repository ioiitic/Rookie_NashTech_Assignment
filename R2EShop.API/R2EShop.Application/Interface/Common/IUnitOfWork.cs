﻿using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Application.Interface.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IDeviceRepository Devices { get; }
        ICaseColorRepository CaseColors { get; }
        ICaseTypeRepository CaseTypes { get; }
        IArtworkRepository Artworks { get; }
        IPhoneCaseRepository PhoneCases { get; }
        Task SaveChangesAsync();
    }
}
