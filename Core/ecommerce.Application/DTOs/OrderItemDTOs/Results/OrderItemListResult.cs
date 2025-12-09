namespace ecommerce.Application.DTOs.OrderItemDTOs.Results
{
    public class OrderItemListResult
    {
        public IEnumerable<OrderItemResult> OrderItems { get; set; } = new List<OrderItemResult>();
        public int TotalCount { get; set; }
    }
}

