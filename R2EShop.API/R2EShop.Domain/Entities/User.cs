using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class User : IAggregateRoot
    {
        public string? Fullname { get; private set; }
        public string? EmailAddress { get; private set; }
        public Address? Address { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? PhotoUrl { get; private set; }

        private User() { }

        private User(string fullname, string emailAddress, Address address, string phoneNumber, string photoUrl)
        {
            Fullname = fullname;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
            PhotoUrl = photoUrl;
        }

        public static User Create(string fullname, string emailAddress, Address address, string phoneNumber, string photoUrl)
        {
            return new User(fullname, emailAddress, address, phoneNumber, photoUrl);
        }
    }
}
