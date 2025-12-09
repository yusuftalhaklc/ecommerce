namespace ecommerce.Application.DTOs.ProductDTOs
{
    public class ProductAttributeValueDto
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}

