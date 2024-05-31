using R2EShop.Application.Interface.Repositories;
using R2EShop.Domain.Entities;
using R2EShop.Infrastructure.Common;
using R2EShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;

namespace R2EShop.Infrastructure.Repositories
{
    public class ArtworkRepository : GenericRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(MyDbContext context) : base(context)
        {
        }

        public IEnumerable<object> GetArtworks(
            string search,
            int minPrice,
            int maxPrice,
            bool IsNew,
            bool IsTrending,
            IList<string>? categoryIds,
            IList<string>? deviceIds,
            IList<string>? caseTypeIds,
            IList<string>? caseColorIds,
            string sortBy,
            bool isAscending,
            int page,
            int pageSize)
        {
            var artworks = _context.Artwork
                .Where(art => art.ArtworkName.Contains(search)
                    && ((IsNew) ? art.IsNew : true)
                    && ((IsTrending) ? art.IsTrending : true))
                .Select(art => new
                {
                    art.Id,
                    art.ArtworkName,
                    PhoneCase = _context.PhoneCase
                        .FirstOrDefault(pc => pc.ArtworkId == art.Id && pc.PhoneCasePrice >= minPrice && pc.PhoneCasePrice <= maxPrice
                        && ((categoryIds == null) ? true : pc.Categories.Any(c => categoryIds.Contains(c.Id.ToString())))
                        && ((deviceIds == null) ? true : deviceIds.Any(dev => pc.DeviceId.ToString() == dev))
                        && ((caseTypeIds == null) ? true : caseTypeIds.Any(col => pc.CaseTypeId.ToString() == col))
                        && ((caseColorIds == null) ? true : caseColorIds.Any(col => pc.CaseColorId.ToString() == col)))
                })
                .Join(
                    _context.PhoneCase,
                    pc1 => pc1.PhoneCase.Id,
                    pc2 => pc2.Id,
                    (pc1, pc2) => new
                    {
                        pc1.Id,
                        pc1.ArtworkName,
                        PhoneCaseId = pc2.Id,
                        pc2.PhoneCasePrice,
                        pc2.DeviceId,
                        pc2.CaseTypeId,
                        pc2.CaseColorId,
                    }
                )
                .Join(
                    _context.Device,
                    t1 => t1.DeviceId,
                    dev => dev.Id,
                    (t1, dev) => new
                    {
                        t1.Id,
                        t1.ArtworkName,
                        t1.PhoneCaseId,
                        t1.PhoneCasePrice,
                        t1.CaseTypeId,
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
                        t2.ArtworkName,
                        t2.PhoneCaseId,
                        t2.PhoneCasePrice,
                        t2.DeviceName,
                        ct.CaseTypeName
                    }
                ).Join(
                    _context.PhoneCase
                        .GroupBy(pc => pc.ArtworkId)
                        .Select(pc => new
                        {
                            ArtworkId = pc.Key,
                            NumberOfColor = pc.Select(pc => pc.CaseColorId).Distinct().Count()
                        }),
                    t3 => t3.Id,
                    grp => grp.ArtworkId,
                    (t3, grp) => new
                    {
                        t3.Id,
                        t3.ArtworkName,
                        t3.PhoneCaseId,
                        t3.PhoneCasePrice,
                        t3.DeviceName,
                        t3.CaseTypeName,
                        grp.NumberOfColor
                    }
                )
            .Select(t4 => new
            {
                t4.Id,
                t4.ArtworkName,
                t4.PhoneCaseId,
                t4.PhoneCasePrice,
                t4.DeviceName,
                t4.CaseTypeName,
                t4.NumberOfColor
            });
            return artworks;

        }
    }
}
