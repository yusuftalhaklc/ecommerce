using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Results
{
    public class EntityTypeResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

