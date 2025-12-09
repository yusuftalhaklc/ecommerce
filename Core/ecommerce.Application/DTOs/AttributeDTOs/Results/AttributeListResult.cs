namespace ecommerce.Application.DTOs.AttributeDTOs.Results
{
    public class AttributeListResult
    {
        public IEnumerable<AttributeResult> Attributes { get; set; } = new List<AttributeResult>();
        public int TotalCount { get; set; }
    }
}

