using MediatR;
using ecommerce.Application.DTOs.CategoryDTOs.Results;

namespace ecommerce.Application.DTOs.CategoryDTOs.Queries
{
    public class GetAllCategoriesQuery : IRequest<CategoryListResult>
    {
    }
}

