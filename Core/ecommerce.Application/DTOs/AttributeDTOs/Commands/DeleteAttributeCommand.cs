using MediatR;

namespace ecommerce.Application.DTOs.AttributeDTOs.Commands
{
    public class DeleteAttributeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

