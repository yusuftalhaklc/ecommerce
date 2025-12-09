using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Queries
{
    public class GetEntityTypeByIdQuery : IRequest<EntityTypeResult?>
    {
        public int Id { get; set; }
    }
}

