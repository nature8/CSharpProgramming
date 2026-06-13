namespace OnlineFoodOrder.API.DTOs;

public class OrderItemCreateDto
{
    public int FoodId { get; set; }
    public int Quantity { get; set; }
}