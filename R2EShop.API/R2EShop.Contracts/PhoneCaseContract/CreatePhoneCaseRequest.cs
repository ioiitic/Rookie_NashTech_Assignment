using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.PhoneCaseContract
{
    public record CreatePhoneCaseRequest(
        string PhoneCaseName,
        double PhoneCasePrice,
        Guid DeviceId,
        Guid CaseTypeId,
        Guid CaseColorId,
        Guid ArtworkId,
        IList<string> Images,
        IList<Guid> CategoryIds);
}
