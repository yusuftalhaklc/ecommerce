using MediatR;
using ecommerce.Application.DTOs.EntityTypeDTOs.Results;

namespace ecommerce.Application.DTOs.EntityTypeDTOs.Queries
{
    public class GetAllEntityTypesQuery : IRequest<EntityTypeListResult>
    {
    }
}

