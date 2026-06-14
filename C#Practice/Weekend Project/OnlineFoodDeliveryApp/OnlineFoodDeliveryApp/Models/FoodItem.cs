using OnlineFoodOrder.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models
{
    public class FoodItem
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        [JsonIgnore]
        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}