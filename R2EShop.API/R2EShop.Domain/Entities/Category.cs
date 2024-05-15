using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Category : Entity
    {
        public string? CategoryName { get; private set; }
        public string? PhotoUrl { get; private set; }

        public Category() { }

        private Category(string categoryName, string photoUrl)
        {
            CategoryName = categoryName;
            PhotoUrl = photoUrl;
        }

        public static Category Create(string categoryName, string photoUrl)
        {
            return new Category(categoryName, photoUrl);
        }
    }
}
