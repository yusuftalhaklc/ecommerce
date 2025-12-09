using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.AddressDTOs.Results
{
    public class AddressResult
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string Title { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

