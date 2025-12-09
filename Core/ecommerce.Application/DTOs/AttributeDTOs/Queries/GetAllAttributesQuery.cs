using MediatR;
using ecommerce.Application.DTOs.AttributeDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeDTOs.Queries
{
    public class GetAllAttributesQuery : IRequest<AttributeListResult>
    {
    }
}

