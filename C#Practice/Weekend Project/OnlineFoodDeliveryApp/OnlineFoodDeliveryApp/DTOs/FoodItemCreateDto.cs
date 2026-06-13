namespace OnlineFoodOrder.API.DTOs;

public class FoodItemCreateDto
{
    public string FoodName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public bool IsAvailable { get; set; }
}