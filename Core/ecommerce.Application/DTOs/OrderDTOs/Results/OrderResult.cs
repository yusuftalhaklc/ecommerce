using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.OrderDTOs.Results
{
    public class OrderResult
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public int ShipperId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

