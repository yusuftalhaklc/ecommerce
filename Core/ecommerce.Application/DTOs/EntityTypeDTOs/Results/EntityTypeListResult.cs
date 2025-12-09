namespace ecommerce.Application.DTOs.EntityTypeDTOs.Results
{
    public class EntityTypeListResult
    {
        public IEnumerable<EntityTypeResult> EntityTypes { get; set; } = new List<EntityTypeResult>();
        public int TotalCount { get; set; }
    }
}

