using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.ProductDTOs.Results
{
    public class ProductResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
        public List<ProductAttributeValueDto> AttributeValues { get; set; } = new();
    }
}

