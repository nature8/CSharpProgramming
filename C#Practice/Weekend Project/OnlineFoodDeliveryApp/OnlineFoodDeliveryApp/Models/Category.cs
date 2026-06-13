using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Navigation
    [JsonIgnore]
    public List<FoodItem> FoodItems { get; set; } = new();
}