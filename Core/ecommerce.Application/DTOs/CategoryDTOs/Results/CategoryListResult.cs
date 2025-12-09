namespace ecommerce.Application.DTOs.CategoryDTOs.Results
{
    public class CategoryListResult
    {
        public IEnumerable<CategoryResult> Categories { get; set; } = new List<CategoryResult>();
        public int TotalCount { get; set; }
    }
}

