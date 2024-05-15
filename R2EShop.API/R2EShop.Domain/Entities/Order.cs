using R2EShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class Order : IAggregateRoot
    {
        public float? TotalPrice { get; private set; }
        public User? OrderUser { get; private set; }
        public virtual IList<OrderItem>? OrderItems { get; private set; }

        private Order() { }
        private Order(float totalPrice, User orderUser, IList<OrderItem> orderItems)
        {
            TotalPrice = totalPrice;
            OrderUser = orderUser;
            OrderItems = orderItems;
        }

        public static Order Create(float totalPrice, User orderUser, IList<OrderItem> orderItems)
        {
            return new Order(totalPrice, orderUser, orderItems);
        }
    }
}
