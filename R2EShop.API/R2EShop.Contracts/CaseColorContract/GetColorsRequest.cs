using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Contracts.CaseColorContract
{
    public record GetColorsRequest(string filter, string range, string sort);
}
