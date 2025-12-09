using MediatR;
using ecommerce.Application.DTOs.AttributeValueDTOs.Results;

namespace ecommerce.Application.DTOs.AttributeValueDTOs.Queries
{
    public class GetAllAttributeValuesQuery : IRequest<AttributeValueListResult>
    {
    }
}

