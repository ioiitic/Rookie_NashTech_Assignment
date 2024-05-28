using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.PhoneCaseContract
{
    public record PhoneCaseResponse(
        Guid Id,
        string PhoneCaseName,
        double PhoneCasePrice,
        string ImageUrl,
        string DeviceName,
        string CaseTypeName,
        string numberOf);
}
