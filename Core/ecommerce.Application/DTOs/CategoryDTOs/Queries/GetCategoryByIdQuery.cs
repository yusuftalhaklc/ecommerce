using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Results;

namespace ecommerce.Application.DTOs.CategoryDTOs.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryResult?>
    {
        public int Id { get; set; }
    }
}

