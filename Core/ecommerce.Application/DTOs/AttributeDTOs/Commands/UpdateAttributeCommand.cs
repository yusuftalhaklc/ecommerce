using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeDTOs.Commands
{
    public class UpdateAttributeCommand : IRequest<AttributeResult>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}

