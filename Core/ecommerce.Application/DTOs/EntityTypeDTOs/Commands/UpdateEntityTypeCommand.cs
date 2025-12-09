using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Commands
{
    public class UpdateEntityTypeCommand : IRequest<EntityTypeResult>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}

