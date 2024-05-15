using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class OrderItem : Entity
    {
        public float? ItemPrice { get; private set; }
        public virtual Product? Product { get; private set; }

        private OrderItem() { }
        private OrderItem(float itemPrice, Product product)
        {
            ItemPrice = itemPrice;
            Product = product;
        }

        public static OrderItem Create(float itemPrice, Product product)
        {
            return new OrderItem(itemPrice, product);
        }
    }
}
