using ecommerce.Domain.Enums;

namespace ecommerce.Application.DTOs.CategoryDTOs.Results
{
    public class CategoryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

