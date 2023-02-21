using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities
{
    public class Order:Auditable
    {
        public long UserId { get; set; }
        public long? PaymentId { get; set; } = null;
        public List<OrderItem> Items { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Unpaid;
        public decimal TotalAmount { get; set; }
    }
}
