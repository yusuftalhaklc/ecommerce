using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.AppUserDTOs.Results
{
    public class AppUserResult
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

