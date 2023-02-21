using FastFood.Domain.Commons;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities
{
    public class Payment:Auditable
    {
        public long OrderId { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
    }
}
