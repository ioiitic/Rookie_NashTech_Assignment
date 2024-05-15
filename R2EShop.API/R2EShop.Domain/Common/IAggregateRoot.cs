using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Common
{
    public abstract class IAggregateRoot : Entity
    {
        protected IAggregateRoot() : base()
        {

        }
    }
}
