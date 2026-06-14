using System.Text.Json.Serialization;

namespace OnlineFoodOrder.API.Models
{

    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;

        [JsonIgnore]
        public Customer? Customer { get; set; }

        [JsonIgnore]
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}