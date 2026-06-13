namespace OnlineFoodOrder.API.DTOs;

public class FoodSearchDto
{
    public string Keyword { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public bool? IsAvailable { get; set; }
}