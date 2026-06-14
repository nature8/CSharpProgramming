using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models
{

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public FoodItem? FoodItem { get; set; }
    }
}