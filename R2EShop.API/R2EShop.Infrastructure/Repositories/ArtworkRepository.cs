using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Common;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Repositories
{
    public class ArtworkRepository : GenericRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<ICollection<object>> GetNewArtWork()
        {
            var artworks = _context.Artwork
                .Where(art => art.IsNew)
                .Join(
                    _context.PhoneCase,
                    art => art.Id,
                    pc => pc.ArtworkId,
                    (art, pc) => new
                    {
                        art.Id,
                        PhoneCaseId = pc.Id,
                        pc.PhoneCasePrice,
                        pc.DeviceId,
                        pc.CaseTypeId,
                        pc.CaseColorId,
                    }
                )
                .Join(
                    _context.Device,
                    t1 => t1.DeviceId,
                    dev => dev.Id,
                    (t1, dev) => new
                    {
                        t1.Id,
                        t1.PhoneCaseId,
                        t1.PhoneCasePrice,
                        t1.DeviceId,
                        t1.CaseTypeId,
                        t1.CaseColorId,
                        dev.DeviceName
                    }
                )
                .Join(
                    _context.CaseType,
                    t2 => t2.CaseTypeId,
                    ct => ct.Id,
                    (t2, ct) => new
                    {
                        t2.Id,
                        t2.PhoneCasePrice,
                        t2.DeviceId,
                        t2.CaseTypeId,
                        t2.CaseColorId,
                        t2.DeviceName,
                        ct.CaseTypeName
                    }
                )
                .Select(t3 => new
                {
                    NumberOfColor = t3,
                });

            return await artworks.ToListAsync();
        }

        public async Task<ICollection<object>> GetTrendingArtwork()
        {
            var artworks = _context.Artwork
                .Where(art => art.IsNew)
                .Join(
                    _context.PhoneCase,
                    art => art.Id,
                    pc => pc.ArtworkId,
                    (art, pc) => new
                    {
                        art.Id,
                        pc.PhoneCasePrice,
                        pc.DeviceId,
                    }
                )
                .Join(
                    _context.Device,
                    t1 => t1.DeviceId,
                    dev => dev.Id,
                    (t1, dev) => new
                    {
                        t1,
                        dev.DeviceName
                    }
                )
                .Select(t2 => new
                {
                    t2.t1.Id,
                    t2.t1.PhoneCasePrice,
                    t2.t1.DeviceId,
                    t2.DeviceName
                });

            return (ICollection<object>)await artworks.ToListAsync();
        }
    }
}
