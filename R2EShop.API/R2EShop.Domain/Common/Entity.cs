using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) 
            {
                return false;   
            }

            var entityObj = (Entity)obj;
            return Id == entityObj.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
