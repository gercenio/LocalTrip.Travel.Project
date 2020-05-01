using System.Collections.Generic;
using System.Linq;
using LocalTrip.Travel.Project.Domain.Enuns;

namespace LocalTrip.Travel.Project.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public Cart Cart { get; }
        
        public Payment Payment { get; private set; }

        public Enuns.OrderStatusType Status { get; private set; }

        public decimal Total { get; private set; }
        public List<OrderItem> Itens { get; private set; }

        public Order(Cart cart, Payment payment)
        {
            Cart = cart;
            Payment = payment;
            Itens = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            Itens.Add(item);
        }

        public void AddPayment(Payment p)
        {
            Payment = p;
        }

        public void AddStatus(OrderStatusType s)
        {
            Status = s;
        }

        public decimal GetTotalValue()
        {
            return Total = Itens.Sum(m => m.Value);
        }

    }
}