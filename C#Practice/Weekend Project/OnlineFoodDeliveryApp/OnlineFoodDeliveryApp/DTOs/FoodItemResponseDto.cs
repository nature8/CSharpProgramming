namespace OnlineFoodOrder.API.DTOs;

public class FoodItemResponseDto
{
    public int FoodId { get; set; }
    public string FoodName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

    
    public string CategoryName { get; set; } = string.Empty;
}