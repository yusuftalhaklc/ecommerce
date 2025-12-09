using MediatR;

namespace ecommerce.Application.DTOs.AttributeValueDTOs.Commands
{
    public class DeleteAttributeValueCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}

