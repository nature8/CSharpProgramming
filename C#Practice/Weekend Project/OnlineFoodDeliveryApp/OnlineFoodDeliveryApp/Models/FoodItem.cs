using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models;

public class FoodItem
{
    [Key]
    public int FoodId { get; set; }

    public string FoodName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    // FK
    public int CategoryId { get; set; }

    // Navigation
    [JsonIgnore]
    public Category Category { get; set; } = null!;

    [JsonIgnore]
    public List<OrderDetail> OrderDetails { get; set; } = new();
}