using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.AttributeValueDTOs.Results
{
    public class AttributeValueResult
    {
        public int Id { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

