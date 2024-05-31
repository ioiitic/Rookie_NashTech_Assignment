using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.PhoneCaseContract
{
    public record Images(string url);
    public record GetPhoneCaseResponse(
        string PhoneCaseName,
        double PhoneCasePrice,
        IList<Images> Images);
}
