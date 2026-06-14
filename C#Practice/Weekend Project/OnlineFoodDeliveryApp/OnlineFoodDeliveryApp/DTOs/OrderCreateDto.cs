namespace OnlineFoodOrder.API.DTOs
{
    public class OrderCreateDto
    {
        public int CustomerId { get; set; }

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}