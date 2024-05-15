using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Product : IAggregateRoot
    {
        public string? ProductName { get; private set; }
        public string? Description { get; private set; }
        public float? ProductPrice { get; private set; }
        public string? PhotoUrl { get; private set; }
        public virtual IList<Category> Categories { get; private set; }
        public virtual IList<Feedback> Feedbacks { get; private set; }

        private Product()
        {
            Categories = new List<Category>();
            Feedbacks = new List<Feedback>();
        }

        private Product(string productName, string description, float productPrice, string photoUrl)
        {
            ProductName = productName;
            Description = description;
            ProductPrice = productPrice;
            PhotoUrl = photoUrl;
            Categories = new List<Category>();
            Feedbacks = new List<Feedback>();
        }

        public static Product Create(string productName, string description, float productPrice, string photoUrl)
        {
            return new Product(productName, description, productPrice, photoUrl);
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void AddFeedback(Feedback feedback)
        {
            Feedbacks.Add(feedback);
        }

        public void RemoveFeedback(Feedback feedback)
        {
            Feedbacks.Remove(feedback);
        }
    }
}
