using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public Address(string street, string city, string state)
        {
            Street = street;
            City = city;
            State = state;
        }

        protected override IEnumerable<object> GetEqualityComponent()
        {
            yield return Street;
            yield return City;
            yield return State;
        }
    }
}
