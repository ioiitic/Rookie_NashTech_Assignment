using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.CaseType
{
    public record GetCaseTypeResponse(
        Guid Id,
        string CaseTypeName,
        int Protection,
        int Weight,
        double AverageStar);
}
