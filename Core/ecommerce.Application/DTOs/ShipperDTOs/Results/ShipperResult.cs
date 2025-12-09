using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.ShipperDTOs.Results
{
    public class ShipperResult
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

