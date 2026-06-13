using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Order> Orders { get; set; } = new();
    
}