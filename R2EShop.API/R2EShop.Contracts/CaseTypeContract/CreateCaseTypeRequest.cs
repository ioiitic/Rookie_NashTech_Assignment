using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.CaseTypeContract
{
    public record CreateCaseTypeRequest(
        string CaseTypeName,
        int Protection,
        int Weight,
        string ImageUrl,
        Guid DeviceId);
}
