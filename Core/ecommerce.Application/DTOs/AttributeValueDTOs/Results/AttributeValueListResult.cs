namespace ecommerce.Application.DTOs.AttributeValueDTOs.Results
{
    public class AttributeValueListResult
    {
        public IEnumerable<AttributeValueResult> AttributeValues { get; set; } = new List<AttributeValueResult>();
        public int TotalCount { get; set; }
    }
}

