using MediatR;

namespace ecommerce.Application.DTOs.CategoryDTOs.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

