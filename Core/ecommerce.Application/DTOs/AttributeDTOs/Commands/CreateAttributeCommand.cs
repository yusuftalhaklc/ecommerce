using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeDTOs.Commands
{
    public class CreateAttributeCommand : IRequest<AttributeResult>
    {
        public string Name { get; set; } = null!;
    }
}

