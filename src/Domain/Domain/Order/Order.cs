namespace BackEnd.Domain.Domain.Order;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
}