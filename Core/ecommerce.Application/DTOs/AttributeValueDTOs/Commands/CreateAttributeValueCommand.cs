using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeValueDTOs.Commands
{
    public class CreateAttributeValueCommand : IRequest<AttributeValueResult>
    {
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; } = null!;
    }
}

