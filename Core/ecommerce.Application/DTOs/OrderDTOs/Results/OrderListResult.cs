namespace ecommerce.Application.DTOs.OrderDTOs.Results
{
    public class OrderListResult
    {
        public IEnumerable<OrderResult> Orders { get; set; } = new List<OrderResult>();
        public int TotalCount { get; set; }
    }
}

