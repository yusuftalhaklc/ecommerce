using MediatR;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Commands
{
    public class DeleteEntityTypeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

