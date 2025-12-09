using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Results;

namespace ecommerce.Application.DTOs.CategoryDTOs.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResult>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? ParentCategoryId { get; set; }
    }
}

