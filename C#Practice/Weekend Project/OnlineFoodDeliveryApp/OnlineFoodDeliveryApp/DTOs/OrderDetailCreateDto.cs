namespace OnlineFoodOrder.API.DTOs
{
    public class OrderDetailCreateDto
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }
}