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
    public class Feedback : Entity
    {
        public float? Score { get; private set; }
        public string? Comment { get; private set; }
        public virtual User? RatingUser { get; private set; }
        public virtual Product? RatingProduct { get; private set; }
        public Feedback() { }

        private Feedback(float score, string comment, User ratingUser, Product ratingProduct)
        {
            Score = score;
            Comment = comment;
            RatingUser = ratingUser;
            RatingProduct = ratingProduct;
        }

        public static Feedback Create(float score, string comment, User ratingUser, Product ratingProduct)
        {
            return new Feedback(score, comment, ratingUser, ratingProduct);
        }
    }
}
