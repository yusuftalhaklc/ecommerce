using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Commands
{
    public class CreateEntityTypeCommand : IRequest<EntityTypeResult>
    {
        public string Name { get; set; } = null!;
    }
}

