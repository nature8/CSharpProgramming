using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models;

public class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = string.Empty;
    // Pending, Preparing, OutForDelivery, Delivered, Cancelled

    [JsonIgnore]
    public Customer Customer { get; set; } = null!;

    [JsonIgnore]
    public List<OrderDetail> OrderDetails { get; set; } = new();
}