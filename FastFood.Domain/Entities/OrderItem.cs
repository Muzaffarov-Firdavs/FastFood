namespace FastFood.Domain.Entities;
public class OrderItem
{
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
